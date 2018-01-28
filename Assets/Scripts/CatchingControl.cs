using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchingControl : MonoBehaviour
{
    public int joystickNum = 1;
    public int throwForce = 20;
    KeyCode catchThrowBall;
    private bool bombEntered;
    private bool bombHolded;
    Collider heldBomb;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Bomb"))
        {
            
            bombEntered = true;
            heldBomb = other;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        bombEntered = false;
    }

    void Start()
    {
        switch (joystickNum)
        {
            case 1:
            case 5:
            default:
                catchThrowBall = KeyCode.Joystick1Button5;
                break;
            case 2:
                catchThrowBall = KeyCode.Joystick2Button5;
                break;
            case 3:
                catchThrowBall = KeyCode.Joystick3Button5;
                break;
            case 4:
                catchThrowBall = KeyCode.Joystick4Button5;
                break;
        }
        bombEntered = false;
        bombHolded = false;
    }

    void Update()
    {
        if (bombHolded && Input.GetKeyDown(catchThrowBall))
        {
            int randomThrow = Random.Range(0, 1);
            switch (randomThrow)
            {
                case 0:
                    transform.parent.GetChild(1).GetComponent<Animator>().SetTrigger("throw");
                    break;
                case 1:
                    transform.parent.GetChild(1).GetComponent<Animator>().SetTrigger("throw2");
                    break;
            }
            bombHolded = false;
            heldBomb.transform.SetParent(null, false);
            heldBomb.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            heldBomb.GetComponent<Rigidbody>().isKinematic = false;
            heldBomb.transform.position = transform.GetChild(0).position;
            heldBomb.GetComponent<Rigidbody>().AddForce(Vector3.Normalize(transform.GetChild(0).position - transform.parent.position) * throwForce, ForceMode.Impulse);
            heldBomb.GetComponent<Rigidbody>().AddForce(transform.up * throwForce, ForceMode.Impulse);
        }
        else if (bombEntered && Input.GetKeyDown(catchThrowBall))
        {
            transform.parent.GetChild(1).GetComponent<Animator>().SetTrigger("catch");
            bombHolded = true;
            bombEntered = false;
            heldBomb.GetComponent<Rigidbody>().isKinematic = true;
            heldBomb.transform.SetParent(transform.GetChild(0), true);
            heldBomb.transform.position = transform.GetChild(0).position;
        }
    }
}
