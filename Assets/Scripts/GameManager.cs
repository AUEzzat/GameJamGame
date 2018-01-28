using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public float bombTimer = 10;
    public GameObject bomb;
    public List<GameObject> players;

    public List<GameObject> regions;
    public GameObject currentRegion;

    // Use this for initialization
    void Start()
    {
        bomb.GetComponent<Bomb>().bombTime = bombTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (bomb.GetComponent<Bomb>().bombTime <= 0)
        {
            print(currentRegion);
            int currentRegionIndex = regions.IndexOf(currentRegion);
            if (currentRegionIndex < 0)
            {
                return;
            }
            Transform currentPlayer = players[currentRegionIndex].transform;
            currentPlayer.GetChild(0).gameObject.SetActive(false);
            currentPlayer.GetChild(1).gameObject.SetActive(false);
            //currentPlayer.GetChild(2).gameObject.SetActive(true);
            bomb.GetComponent<Bomb>().bombTime = bombTimer;
            StartCoroutine(RegenerateBomb());
        }
    }
    IEnumerator RegenerateBomb()
    {
        bomb.GetComponent<MeshRenderer>().enabled = false;
        //bomb.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        print(players.Capacity);
        List<GameObject> activePlayers = new List<GameObject>();
        for (int i = 0; i < 4; i++)
        {
            if (players[i].transform.GetChild(0).gameObject.activeSelf)
            {
                activePlayers.Add(players[i]);
            }
        }
        if (activePlayers.Count == 1)
        {
            SceneManager.UnloadSceneAsync(0);
            SceneManager.LoadSceneAsync(0);
        }
        else
        {
            int randomPlayer = Random.Range(0, activePlayers.Count);
            print(players.IndexOf(activePlayers[randomPlayer]));
            bomb.transform.position = regions[players.IndexOf(activePlayers[randomPlayer])].transform.position;
        }
        bomb.GetComponent<MeshRenderer>().enabled = true;
        //bomb.transform.GetChild(0).gameObject.SetActive(false);
    }
}
