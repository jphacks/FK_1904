using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;


public class MenuScene : MonoBehaviour
{
    public GameObject SelectRoomScreen;
    public GameObject MakeRoomScreen;
    public GameObject RawImage;


    [SerializeField] private PhotonManager photonManager;

    // Start is called before the first frame update
    void Start()
    {

        RawImage.SetActive(true);

        // if (UserData.Instance.MASTER == true)
        // {
        //     MakeRoomScreen.SetActive(true);
        //     SelectRoomScreen.SetActive(false);
        // }
        // else
        // {
        //     MakeRoomScreen.SetActive(false);
        //     SelectRoomScreen.SetActive(true);
        // }


    }


    // Update is called once per frame
    void Update()
    {

    }

    void Awake()
    {
        // PhotonPlayer
    }
}
