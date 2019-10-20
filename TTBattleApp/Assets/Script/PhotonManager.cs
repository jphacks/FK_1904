using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Photon;
using Random = UnityEngine.Random;
using ExitGames.Client.Photon;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PhotonManager : Photon.MonoBehaviour
{

    public bool isMaster = false;

    private bool connectFailed = false;
    [SerializeField] private MenuScene menuSceneScript;

    void Start()
    {
        // Photonネットワークの設定を行う
        // PhotonNetwork.ConnectUsingSettings(null);
        // PhotonNetwork.sendRate = 30;
        UserData.Instance.MASTER = false;
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

    // 「ロビー」に接続した際に呼ばれるコールバック
    public void OnJoinedLobby()
    {
        Debug.Log("OnJoinedLobby");
        PhotonNetwork.JoinRandomRoom();
    }

    // いずれかの「ルーム」への接続に失敗した際のコールバック
    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("OnPhotonRandomJoinFailed");

        isMaster = true;
        UserData.Instance.MASTER = true;

        // ルームを作成（今回の実装では、失敗＝マスタークライアントなし、として「ルーム」を作成）
        PhotonNetwork.autoCleanUpPlayerObjects = false;
        // //カスタムプロパティ
        ExitGames.Client.Photon.Hashtable customProp = new ExitGames.Client.Photon.Hashtable();
        customProp.Add("userName", PhotonNetwork.playerName); //プレイヤー名
        customProp.Add("isMaster", isMaster); //親プレイヤーの判別
        PhotonNetwork.SetPlayerCustomProperties(customProp);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.CustomRoomProperties = customProp;
        // //ロビーで見えるルーム情報としてカスタムプロパティのuserName,userIdを使いますよという宣言
        roomOptions.CustomRoomPropertiesForLobby = new string[] { "isMaster" };
        roomOptions.MaxPlayers = 2; //部屋の最大人数
        roomOptions.IsOpen = true; //入室許可する
        roomOptions.IsVisible = true; //ロビーから見えるようにする
        roomOptions.PublishUserId = true;
        PhotonNetwork.CreateRoom(null, roomOptions, null);
        PhotonNetwork.CreateRoom(null);
    }

    // //部屋作成に成功したときにコール
    // public new void OnCreatedRoom()
    // {
    //     Debug.Log("OnCreatedRoom");
    // }

    // ルーム一覧が取れると
    void OnReceivedRoomListUpdate()
    {
        //ルーム一覧を取る
        RoomInfo[] rooms = PhotonNetwork.GetRoomList();
        RoomData.Instance.roomArray = rooms;
        if (rooms.Length == 0)
        {
            Debug.Log("ルームが一つもありません");
        }
        else
        {
            //ルームが1件以上ある時ループでRoomInfo情報をログ出力
            for (int i = 0; i < rooms.Length; i++)
            {
                // Debug.Log("RoomName:" + rooms[i].name + ", userName:" + rooms[i].customProperties["userName"] + ", monsterId:" + rooms[i].customProperties["monsterId"]);
            }
        }
    }

    // Photonサーバに接続した際のコールバック
    public void OnConnectedToPhoton()
    {
        Debug.Log("OnConnectedToPhoton");
    }

    // マスタークライアントに接続した際のコールバック
    public void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster");
        PhotonNetwork.JoinRandomRoom();
    }

    // いずれかの「ルーム」に接続した際のコールバック
    public void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");
        // Debug.Log(PhotonPlayer.CustomProperties["isMaster"].ToString());
        if (UserData.Instance.MASTER == true)
        {
            menuSceneScript.MakeRoomScreen.SetActive(true);
            menuSceneScript.SelectRoomScreen.SetActive(false);
        }
        else
        {
            menuSceneScript.MakeRoomScreen.SetActive(false);
            menuSceneScript.SelectRoomScreen.SetActive(true);
        }
        menuSceneScript.RawImage.SetActive(false);
        SceneManager.LoadScene("BattleSceneYamada");


    }

    // 部屋を作れなかった時
    public void OnPhotonCreateGameFailed()
    {
        PhotonNetwork.JoinRandomRoom();
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
        Debug.Log("PhotonPlayer:" + PhotonNetwork.playerName);
        //ローディング画面表示


    }

    // リモートプレイヤーが退室した際にコールされる
    public void OnPhotonPlayerDisconnected(PhotonPlayer player)
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



    //接続が切断されたときにコール
    public void OnDisconnectedFromPhoton()
    {
        Debug.Log("Disconnected from Photon.");
    }

    //接続失敗時にコール
    public void OnFailedToConnectToPhoton(object parameters)
    {
    }

}
