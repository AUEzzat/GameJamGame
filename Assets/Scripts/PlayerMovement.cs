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
    public float angleLimit = 45;
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
        float forwardRot = (float)(90 - Math.Atan2(transform.forward.z, transform.forward.x) * 180 / 3.14);
        Vector3 lAX = new Vector3(Input.GetAxis(Enum.GetName(typeof(AxisName), leftHorizAxisName)), 0,
             -Input.GetAxis(Enum.GetName(typeof(AxisName), leftVerAxisName)));
        float rHAX = Input.GetAxis(Enum.GetName(typeof(AxisName), rightHorizAxisName));
        float rVAX = Input.GetAxis(Enum.GetName(typeof(AxisName), rightVerAxisName));
        if (lAX.magnitude < deadZone)
        {
            lAX = Vector3.zero;
        }
        else
        {
            playerRB.AddForce(lAX * moveForce);
            playerRB.transform.forward = Vector3.Lerp(playerRB.velocity, lAX, Time.deltaTime);
            //Debug.Log(90 - Math.Atan2(transform.forward.z, transform.forward.x) * 180 / 3.14);
        }

        if (Math.Abs(rHAX) < deadZone)
        {
            rHAX = 0;
        }
        else
        {
            aimArrow.transform.Rotate(0, rHAX * rotationSpeed, 0);
            float forwardRotDiff = Math.Abs(forwardRot - aimArrow.transform.rotation.eulerAngles.y);
            //Debug.Log(forwardRotDiff);
            if (forwardRotDiff > angleLimit && forwardRotDiff < 360 - angleLimit)
                aimArrow.transform.Rotate(0, -rHAX * rotationSpeed, 0);
            Debug.Log(aimArrow.transform.rotation.eulerAngles.y);
        }
        if (Math.Abs(rVAX) < deadZone)
        {
            rVAX = 0;
        }
        else
        {
            aimArrow.transform.Rotate(0, rVAX * rotationSpeed, 0);
            float forwardRotDiff = Math.Abs(forwardRot - aimArrow.transform.rotation.eulerAngles.y);
            //Debug.Log(forwardRotDiff);
            if (forwardRotDiff > angleLimit && forwardRotDiff < 360 - angleLimit)
                aimArrow.transform.Rotate(0, -rVAX * rotationSpeed, 0);
            Debug.Log(aimArrow.transform.rotation.eulerAngles.y);
        }
    }
}
