using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    public int otherIndex;
    public int index;
    // Use this for initialization

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bomb"))
        {
            Transform parent = GetComponentInParent<portalManager>().Portals[otherIndex].transform;
            Transform sonny = parent.GetChild(0);
            if (!other.transform.parent)
            {
                other.transform.SetParent(null, false);
            }
            other.gameObject.transform.position = sonny.position;
            other.GetComponent<Rigidbody>().velocity = Vector3.Normalize(sonny.position - parent.position) * 6;
            if (other.transform.childCount == 3)
                other.transform.GetChild(2).gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.childCount == 3)
            other.transform.GetChild(2).gameObject.SetActive(false);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


}
