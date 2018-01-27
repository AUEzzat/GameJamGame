using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    public int otherIndex;
    public int index;
    // Use this for initialization

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bomb"))
        {
            Transform parent = GetComponentInParent<portalManager>().Portals[otherIndex].transform;
            Transform brudah = parent.GetChild(0);
            if (!other.transform.parent)
                other.transform.SetParent(null, false);
            other.gameObject.transform.position = brudah.position;
            other.GetComponent<Rigidbody>().velocity = Vector3.Normalize(brudah.position - parent.position) * 6;
        }
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
