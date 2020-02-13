# coding:utf-8

import math
import wave
import struct
import time
import threading
import serial
import requests
import csv
import socket


# Global settings of for the serial port
comPort = "/dev/ttyACM0"
baudrate = 1000000
# .wav params
nchannels = 1
sampwidth = 4
nframes = 0
sampleRate = 11000
comptype = "NONE"
compname = "not compressed"
# Open a wav file
wavFile=wave.open("output.wav", "w")
# Set the parameters of the wave file
wavFile.setparams((nchannels, sampwidth, sampleRate, nframes, comptype, compname))
# Create an instance of the serial port
serInstance = serial.Serial(comPort, baudrate, timeout=0)
# Buffer the last value in case of data dropping​
lastValueFromStream = b''


print("pretend")
numList = [0] * 10

def processAudioData():
    HOST0 = '192.168.1.89'#こーた
    #HOST1 = '192.168.1.65'#山田
    sendFlag = False

    PORT = 50007
    client = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
    sleepTime = 0.1
    # Create a byte object for storing the returned values from the serial port
    returnedValue = b''
    # Variable to store the available bytes from the serial buffer
    bytesToRead = 1
    count = 0
    csv_data = []
    sendn = 600
    sendCount = 0#送った回数
    while bytesToRead != 0:
        global lastValueFromStream
        # Check whether bytes are available for reading
        bytesToRead = serInstance.inWaiting()

        # If we have nothing to do, just leave the while loop
        if count == sendn:#countがsendn(11000)の時、breakして終了
            wavFile.close()
            print("success")
            break
        if bytesToRead == 0:
            wavFile.close()
            break
        # Read the bytes and save them in the returnedValue variable
        returnedValue = serInstance.read(bytesToRead)
        # Split the bytes with new line as a delimiter
        returnedValue = returnedValue.split(b'\n')
        # Process the splitted values
        for value in returnedValue:
            if count == sendn:
                break
            start = time.time()
            # We send three bytes - if we receive less or more, we drop the result
            if len(value) != 3:
                #continue
                value = lastValueFromStream
            lastValueFromStream = value
            # Create an integer from the binary values
            integer = int.from_bytes(value, byteorder='big', signed=True)
            # Due to transmission errors, there might be values above/below the maximum value
            # We receive 20 bit signed integer values which have a maximum value of (2^19-1) and minimum value (-2^19)
            if integer < -524288 or integer > 524287:
                print("crazy")
                continue

            # Parse the integer to a signed 32 bit value with maximum value of +/-2^31-1 = 2147483647
            # Note that there is an error of +/- 1 due to asymmetric max. values
            parse = int(float((float(integer)/524288))*(2147483647))
            # Write the values to the wave file
            wavFile.writeframes(struct.pack('i', parse))
            print(parse)
            parseSTR = str(abs(parse))[0]
            numList[int(str(abs(parse))[0])] += 1
            client.sendto(parseSTR.encode('utf-8'), (HOST0, PORT))
            print("{:}回目, send Magnitude = {:}".format(count, parseSTR))
            time.sleep(sleepTime)
            csv_data.append(parse)
            count += 1

            # send request to webhook
            # response = requests.post('https://maker.ifttt.com/trigger/Player1_TT_v2/with/key/hnXromm5rMulX5fW03d7s', data={'value1': parse})

            # print(response.status_code)    # HTTPのステータスコード取得
            # print(response.text)

        with open('view_data.csv', 'a') as f:
            writer = csv.writer(f)
            writer.writerow(csv_data)
    return 

if __name__ == '__main__':
    start = time.time()
    while True:
        processAudioData()
        break
    serInstance.close()
    print(numList)
    print("elapsed_time = ", time.time() - start)
