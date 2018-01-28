using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionEntered : MonoBehaviour {

    public GameObject gameManaga;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bomb"))
        {
            gameManaga.GetComponent<GameManager>().currentRegion = transform.gameObject;
        }
    }
}
