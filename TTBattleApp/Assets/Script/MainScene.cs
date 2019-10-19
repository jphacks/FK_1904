// using System.Collections;
// using System.Collections.Generic;
// using UnityEditor;
// using UnityEngine;
// using UnityEngine.EventSystems;
// using UnityEngine.SceneManagement;
// using UnityEngine.UI;
// using System;


// public class MainScene : MonoBehaviour
// {
//     // User情報の保持
//     public string playerName;
//     public bool isMaster = true;

//     // シーンに表示されているオブジェクトとの関連付け
//     // Menuシーン内で画面を切り替えるため
//     public GameObject LobbyScreen;
//     public GameObject SelectRoomScreen;
//     public GameObject MakeRoomScreen;
//     // グループオブジェクトの関連付け
//     public GameObject RoomGroupPanel;
//     public GameObject UserGroupPanel;
//     // プレハブとの関連付け
//     public GameObject PreRoomButton;
//     public GameObject EntryUserImage;
//     // ボタンの関連付け
//     // public Button MakeButton;
//     // public Button SelectButton;

//     // 配列とか
//     public RoomInfo[] RoomArray; // 取得したルームを配列に保存;




//     // Photon関連のファイル呼び出し
//     [SerializeField] private PhotonManager photonManager;

//     // Start is called before the first frame update
//     void Start()
//     {
//         // オブジェクトの表示切り替え
//         LobbyScreen.SetActive(true);
//         SelectRoomScreen.SetActive(false);
//         MakeRoomScreen.SetActive(false);

//         PreRoomButton = (GameObject)Resources.Load("Prehub/RoomButton");



//     }

//     // Update is called once per frame
//     void Update()
//     {

//     }

//     // 対戦開始。バトルシーンに移動
//     public void BattleStart()
//     {
//         SceneManager.LoadScene("BattleScene");
//     }

//     public void MakeRoomButton()
//     {
//         // オブジェクトの表示切り替え
//         LobbyScreen.SetActive(false);
//         SelectRoomScreen.SetActive(false);
//         MakeRoomScreen.SetActive(true);

//         playerName = UserData.Instance.USER_NAME;
//         Debug.Log(playerName);
//         photonManager.CreateRoom(playerName, isMaster);
//     }

//     public void SelectRoomButton()
//     {

//         // オブジェクトの表示切り替え
//         LobbyScreen.SetActive(false);
//         SelectRoomScreen.SetActive(true);
//         MakeRoomScreen.SetActive(false);

//         RoomInfo[] rooms = RoomData.Instance.roomArray;

//         for (int count = 0; count < rooms.Length; count++)
//         {
//             Button RoomButton;
//             GameObject RoomButtonObj = (GameObject)Instantiate(PreRoomButton, transform.position, Quaternion.identity);
//             RoomButtonObj.transform.SetParent(RoomGroupPanel.transform);
//             RoomButton = RoomButtonObj.GetComponent<Button>();
//             RoomButton.name = rooms[count].name;
//             RoomButton.onClick.AddListener(() => SelectRoomButton(RoomButton));

//             Text RoomNameText;
//             RoomNameText = RoomButton.GetComponentInChildren<Text>();
//             RoomNameText.text = rooms[count].customProperties["userName"] + "が作った部屋";
//         }

//     }

//     public void SelectRoomButton(Button btn)
//     {
//         // 選択したルームに参加
//         isMaster = false;
//         photonManager.JoinRoom(btn.name, playerName, isMaster);

//         LobbyScreen.SetActive(false);
//         MakeRoomScreen.SetActive(false);
//         SelectRoomScreen.SetActive(false);

//     }

//     public void MakeEntoryUser(PhotonPlayer user)
//     {
//         Image userImage;
//         GameObject EntryUserImageObj = (GameObject)Instantiate(EntryUserImage, transform.position, Quaternion.identity);
//         EntryUserImageObj.transform.SetParent(UserGroupPanel.transform);
//         userImage = EntryUserImageObj.GetComponent<Image>();
//         userImage.sprite = EntryUserImageArray[(int)user.CustomProperties["monsterId"] - 1];

//         Text userNameText;
//         userNameText = userImage.GetComponentInChildren<Text>();
//         userNameText.text = user.CustomProperties["userName"].ToString();
//     }

// }
