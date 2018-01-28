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
    Transform currentPlayer;
    // Update is called once per frame
    void Update()
    {

        if (bomb.GetComponent<Bomb>().bombTime <= 0)
        {
            if (bomb.GetComponents<AudioSource>()[0].isPlaying)
                bomb.GetComponents<AudioSource>()[0].Stop();
            bomb.GetComponents<AudioSource>()[1].Play();
            bomb.transform.GetChild(0).gameObject.SetActive(true);
            int currentRegionIndex = regions.IndexOf(currentRegion);
            if (currentRegionIndex < 0)
            {
                return;
            }
            currentPlayer = players[currentRegionIndex].transform;
            currentPlayer.GetChild(1).GetComponent<Animator>().SetTrigger("die");
            bomb.GetComponent<Bomb>().bombTime = bombTimer;
            StartCoroutine(RegenerateBomb());
        }
        else if (bomb.GetComponent<Bomb>().bombTime <= 1.5)
        {
            if (!bomb.GetComponents<AudioSource>()[0].isPlaying
                && !bomb.GetComponents<AudioSource>()[1].isPlaying)
                bomb.GetComponents<AudioSource>()[0].Play();
        }
    }
    IEnumerator RegenerateBomb()
    {
        bomb.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(2);
        currentPlayer.GetChild(0).gameObject.SetActive(false);
        currentPlayer.GetChild(1).gameObject.SetActive(false);
        bomb.transform.GetChild(0).gameObject.SetActive(false);
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
    }
}
