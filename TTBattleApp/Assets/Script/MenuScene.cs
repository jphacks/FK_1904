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

    // オーディオの関連付け
    AudioSource audioSource;
    public GameObject SE_AudioObject;
    public AudioClip push_next;



    [SerializeField] private PhotonManager photonManager;

    // Start is called before the first frame update
    void Start()
    {

        RawImage.SetActive(true);
        audioSource = SE_AudioObject.GetComponent<AudioSource>();

    }


    // Update is called once per frame
    void Update()
    {

    }

    void Awake()
    {
        // PhotonPlayer
    }

    public void BattleStart()
    {
        SceneManager.LoadScene("BattleScene");
    }
}
