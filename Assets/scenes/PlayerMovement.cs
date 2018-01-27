using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AxisName
{
    LH1,
    LH2,
    LH3,
    LH4,
    LH5,
    LV1,
    LV2,
    LV3,
    LV4,
    LV5,
    RH1,
    RH2,
    RH3,
    RH4,
    RH5,
    RV1,
    RV2,
    RV3,
    RV4,
    RV5
}
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody playerRB;
    public AxisName horizontalAxisName;
    public AxisName verticalAxisName;
    public float deadZone = 0.6f;
    // Use this for initialization
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float hAX =  Input.GetAxis(Enum.GetName(typeof(AxisName), horizontalAxisName));
        float vAx =  Input.GetAxis(Enum.GetName(typeof(AxisName), verticalAxisName));
        if (Math.Abs(hAX) < deadZone)
        {
            hAX = 0;
        }
        else
        {
            playerRB.velocity = new Vector3(0, 0, hAX * speed);
            print(hAX);
        }
        if (Math.Abs(vAx) < deadZone) {
            vAx = 0;
        }
            
        else
        {
            playerRB.velocity = new Vector3(vAx*speed, 0, 0);
            print(vAx);
        }
    }
}
