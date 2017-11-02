using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour {

    private string strPlayer;
    private int numPlayers;
    private int currentPlayer;

    public Transform playerPos;
    public Transform waitingPlayerPos;

	// Use this for initialization
	void Start () 
    {
        strPlayer = "turtle";
        numPlayers = 3;
        currentPlayer = 0;
        preparePlayers();
        createPlayer();
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    public void createPlayer()
    {
        GameObject playerPrefab = (GameObject)Resources.Load("Prefabs/Players/"+strPlayer, typeof(GameObject));
        if (playerPrefab && numPlayers > 0)
        {
            Instantiate(playerPrefab, playerPos.position, playerPrefab.transform.rotation);
            numPlayers--;
            currentPlayer++;
        }
    }

    public string getSelectedPlayer()
    {
        return strPlayer;
    }

    public int getNumOfPlayers()
    {
        return numPlayers;
    }

    void preparePlayers()
    {
        for(int i=0; i<numPlayers-1;i++)
        {
            GameObject playerPrefab = (GameObject)Resources.Load("Prefabs/Waiting Players/waiting " + strPlayer, typeof(GameObject));
            if(playerPrefab)
            {              
                Instantiate(playerPrefab, new Vector2(waitingPlayerPos.position.x - i * 1.6f, waitingPlayerPos.position.y), playerPrefab.transform.rotation);
            }
        }
    }

    public void getPlayerReady()
    {
        if(transform.childCount > 0)
        {
            transform.GetChild(0).gameObject.GetComponent<WaitingPlayerController>().setReady();
        }
    }

}
