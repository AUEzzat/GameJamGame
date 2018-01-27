using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalManager : MonoBehaviour {

    public int disapperTime = 2;
    public int coolDown = 4;
    public Portal []Portals;

    public int first=-1;
    public int second=-1;

    
    // Use this for initialization
    void Start () {
        for (int i = 0; i < Portals.Length; i++)
        {
            Portals[i].index = i;
        }
        StartCoroutine(randPortal());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator randPortal()
    {
        while (true)
        {
            first = Random.Range(0,Portals.Length);
            second = Random.Range(0,Portals.Length);

            Portals[first].index = first;
            Portals[first].otherIndex = second;

            Portals[second].index = second;
            Portals[second].otherIndex = first;

            Portals[first].gameObject.SetActive(true);
            Portals[second].gameObject.SetActive(true);

            yield return new WaitForSeconds(disapperTime);

            Portals[first].index = -1;
            Portals[first].otherIndex = -1;

            Portals[second].index = -1;
            Portals[second].otherIndex = -1;

            Portals[first].gameObject.SetActive(false);
            Portals[second].gameObject.SetActive(false);

            first = -1;
            second = -1;
            yield return new WaitForSeconds(coolDown);
        }
    }

}
