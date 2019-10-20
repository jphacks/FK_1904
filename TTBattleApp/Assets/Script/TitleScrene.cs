using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using UnityEditor;

public class TitleScrene : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip push_next;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToMenuScene()
    {
        // ボタン選択時の効果音
        // audioSource.PlayOneShot(push_next);
        SceneManager.LoadScene("MenuScene");

    }

}