using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miraichan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localEulerAngles.z > 70){
//Debug.Log(transform.localEulerAngles.z); 30 -> 90
        //if (transform.localEulerAngles.z > 0.5){
//Debug.Log(transform.rotation.z); 0.2 -> 0.7
            Debug.Log("GameOver");
            //Time.timeScale = 0;
        }

    }
}
