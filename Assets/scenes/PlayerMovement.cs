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
    public AxisName leftHorizAxisName;
    public AxisName leftVerAxisName;
    public AxisName rightHorizAxisName;
    public AxisName rightVerAxisName;
    public float deadZone = 0.6f;
    public float moveForce = 30;
    Transform aimArrow;
    // Use this for initialization
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        aimArrow = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lAX = new Vector3(Input.GetAxis(Enum.GetName(typeof(AxisName), leftHorizAxisName)), 0,
             -Input.GetAxis(Enum.GetName(typeof(AxisName), leftVerAxisName)));
        Vector3 rAX = new Vector3(Input.GetAxis(Enum.GetName(typeof(AxisName), rightHorizAxisName)), 0,
             Input.GetAxis(Enum.GetName(typeof(AxisName), rightVerAxisName)));
        if (lAX.magnitude< deadZone)
        {
            lAX = Vector3.zero;
        }
        else
        {
            playerRB.AddForce(lAX * moveForce);
            playerRB.transform.forward = Vector3.Lerp(playerRB.velocity, lAX, Time.deltaTime);
        }

        if (rAX.magnitude < deadZone)
        {
            rAX = Vector3.zero;
        }
        else
        {
            aimArrow.transform.Rotate((float)Math.Sin(Vector3.Dot(transform.forward, rAX)),0 , (float)Math.Cos(Vector3.Dot(transform.forward, rAX)));
        }
    }
}
