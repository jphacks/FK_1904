using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Photon;
using Random = UnityEngine.Random;
using ExitGames.Client.Photon;
using UnityEngine.UI;

public class PhotonManager : Photon.MonoBehaviour
{

    void Start()
    {
    }
    void Update()
    {
    }

    public void Awake()
    {
        // マスタークライアントのsceneと同じsceneを部屋に入室した人もロードする。
        PhotonNetwork.automaticallySyncScene = true;

        // もしまだ接続していない状態のとき
        if (PhotonNetwork.connectionStateDetailed == ClientState.PeerCreated)
        {
            // PhotonServerSettingsの設定に従ってPhotonNetwork（マスターサーバー）に接続する。
            PhotonNetwork.ConnectUsingSettings(null);
        }

        // もしPhotonNetWorkに名前を登録していないならば、PhotonNetworkに名前を登録する
        if (String.IsNullOrEmpty(PhotonNetwork.playerName))
        {
            PhotonNetwork.playerName = "Guest" + Random.Range(1, 9999);
        }

        // if you wanted more debug out, turn this on:
        // PhotonNetwork.logLevel = NetworkLogLevel.Full;
    }


    public void CreateRoom(string userName, int monsterId, bool isMaster)
    {
        PhotonNetwork.autoCleanUpPlayerObjects = false;
        //カスタムプロパティ
        ExitGames.Client.Photon.Hashtable customProp = new ExitGames.Client.Photon.Hashtable();

        customProp.Add("userName", userName); //ユーザ名
        customProp.Add("monsterId", monsterId); //選んだモンスターの識別ID
        customProp.Add("isMaster", isMaster); //親プレイヤーの判別
        PhotonNetwork.SetPlayerCustomProperties(customProp);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.customRoomProperties = customProp;
        //ロビーで見えるルーム情報としてカスタムプロパティのuserName,userIdを使いますよという宣言
        roomOptions.customRoomPropertiesForLobby = new string[] { "userName", "monsterId", "isMaster" };
        roomOptions.maxPlayers = 5; //部屋の最大人数
        roomOptions.isOpen = true; //入室許可する
        roomOptions.isVisible = true; //ロビーから見えるようにする
        roomOptions.PublishUserId = true;
        PhotonNetwork.CreateRoom(null, roomOptions, null);

    }

    public void GetRoomList()
    {

    }

    // ルーム一覧が取れると
    void OnReceivedRoomListUpdate()
    {

    }

    public void JoinRoom(string roomName, string userName, int monsterId, bool isMaster)
    {


    }

    public void LeftRoom()
    {

    }

    // 抜けられたらこの関数がよばれるからここでシーンを切り替えるなりする
    public void OnLeftRoom()
    {

    }

    // リモートプレイヤーが入室した際にコールされる
    public void OnPhotonPlayerConnected(PhotonPlayer player)
    {


    }

    // リモートプレイヤーが退室した際にコールされる
    public void OnPhotonPlayerDisconnected(PhotonPlayer player)
    {

    }

    // ロビーに入ったタイミングでコール
    void OnJoinedLobby()
    {
        Debug.Log("PhotonManager OnJoinedLobby");
    }

    //入室時にコール
    public void OnJoinedRoom()
    {

    }

    //部屋作成に失敗したときにコール
    public void OnPhotonCreateRoomFailed()
    {
        Debug.Log("OnPhotonCreateRoomFailed got called. This can happen if the room exists (even if not visible). Try another room name.");
    }

    //入室に失敗したときにコール
    public void OnPhotonJoinRoomFailed(object[] cause)
    {
        Debug.Log("OnPhotonJoinRoomFailed got called. This can happen if the room is not existing or full or closed.");
    }

    //部屋作成に成功したときにコール
    public void OnCreatedRoom()
    {
        Debug.Log("OnCreatedRoom");
    }

    //接続が切断されたときにコール
    public void OnDisconnectedFromPhoton()
    {
        Debug.Log("Disconnected from Photon.");
    }

    //接続失敗時にコール
    public void OnFailedToConnectToPhoton(object parameters)
    {

    }

    public void OnConnectedToMaster()
    {
        Debug.Log("As OnConnectedToMaster() got called, the PhotonServerSetting.AutoJoinLobby must be off. Joining lobby by calling PhotonNetwork.JoinLobby().");
        PhotonNetwork.JoinLobby();
    }

}
