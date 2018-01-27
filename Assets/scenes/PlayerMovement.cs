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
    public float rotationSpeed = 5;
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
        float rHAX = Input.GetAxis(Enum.GetName(typeof(AxisName), rightHorizAxisName));
        //float rVAX = Input.GetAxis(Enum.GetName(typeof(AxisName), rightVerAxisName));
        if (lAX.magnitude < deadZone)
        {
            lAX = Vector3.zero;
        }
        else
        {
            playerRB.AddForce(lAX * moveForce);
            playerRB.transform.forward = Vector3.Lerp(playerRB.velocity, lAX, Time.deltaTime);
        }

        if (Math.Abs(rHAX) < deadZone)
        {
            rHAX = 0;
        }
        else
        {
            float yRotation= 0 ;
                aimArrow.transform.Rotate(0, rHAX * rotationSpeed, 0);
            if (aimArrow.transform.rotation.y < 30 || aimArrow.transform.rotation.y > 330)
                yRotation = -rHAX * rotationSpeed;
            aimArrow.transform.Rotate(0, yRotation, 0);

        }
    }
}
