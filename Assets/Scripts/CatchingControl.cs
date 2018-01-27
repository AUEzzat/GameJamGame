using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchingControll : MonoBehaviour
{

    private bool triggerEntered;
    Collider obj;

    private void OnTriggerStay(Collider other)
    {
        if (other.GetType() == typeof(SphereCollider))
        {
            triggerEntered = true;
            obj = other;
            Debug.Log("trigger entered");
        }

    }
    void Start()
    {
        triggerEntered = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick2Button5) && triggerEntered == true)
        {
            Debug.Log("Key pressed");
            obj.transform.position = this.transform.position;
            obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
            obj.transform.SetParent(this.transform, false);
        }
    }
}
