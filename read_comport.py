#coding:utf-8

import math
import wave
import struct
import time
import threading
import serial

# Global settings of for the serial port
comPort = "COM3"
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
print("end")