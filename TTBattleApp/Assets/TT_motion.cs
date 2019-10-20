using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TT_motion : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}


    float hold_time = 0;
    float hold_time1 = 0.3f;
    float time_threshold = 1f;

    private void FixedUpdate()
    {




        hold_time += Time.deltaTime;
        //Player1のTT処理
        if(hold_time > time_threshold)
        {
            Rigidbody rb = this.GetComponent<Rigidbody>();
            int push_x = Random.Range(0, 40);
            int push_z = Random.Range(-40, 40);
            //Debug.LogFormat("Player1 :: x座標:{0}, z座標:{1}", push_x, push_z);
            Vector3 force = new Vector3(0.0f, -10.0f, 0.0f);
            Vector3 pos = new Vector3(push_x, 3.1f, push_z);
            rb.AddForceAtPosition(force, pos, ForceMode.Impulse);

            hold_time = 0;
        }

        hold_time1 += Time.deltaTime;
        //Player2のTT処理
        if (hold_time1 > time_threshold)
        {
            Rigidbody rb = this.GetComponent<Rigidbody>();
            int push_x = Random.Range(-40, 0);
            int push_z = Random.Range(-40, 40);
            //Debug.LogFormat("Player2 :: x座標:{0}, z座標:{1}", push_x, push_z);
            Vector3 force = new Vector3(0.0f, -10.0f, 0.0f);
            Vector3 pos = new Vector3(push_x, 3.1f, push_z);
            rb.AddForceAtPosition(force, pos, ForceMode.Impulse);

            hold_time1 = 0;
        }
    }
}
