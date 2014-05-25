using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NetworkManager : MonoBehaviour {

    public delegate void ReadyAction();
    public static event ReadyAction GameIsReady;


    private static PhotonView ScenePhotonView;
    public static int playerWhoIsIt;
    private RotateWhenDef camera;

	// Use this for initialization
	void Start () {
        PhotonNetwork.ConnectUsingSettings("0.1");
         ScenePhotonView = this.GetComponent<PhotonView>();
         camera = GameObject.FindGameObjectWithTag("Camera").GetComponent<RotateWhenDef>();
	}

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }

    void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("Can't join random room!");
        PhotonNetwork.CreateRoom(null);
    }

    void OnJoinedRoom()
    {
        if (PhotonNetwork.playerList.Length == 1)
        {
            playerWhoIsIt = PhotonNetwork.player.ID;
            PhotonNetwork.player.currentState = PhotonPlayer.State.ATTACKER;
           // PhotonNetwork.player.Name = "Attacker";
           // PhotonNetwork.player.MaxHealth = 1;
          //  PhotonNetwork.player.Health = 1;
          //  PhotonNetwork.player.StartingGold = 50;
        }
        else
        {
            PhotonNetwork.player.currentState = PhotonPlayer.State.DEFENDER;
         //   PhotonNetwork.player.Name = "Defender";
          //  PhotonNetwork.player.MaxHealth = 50;
          //  PhotonNetwork.player.Health = 50;
          //  PhotonNetwork.player.StartingGold = 50;
            camera.CameraDefRotate();
        }

        Debug.Log("playerWhoIsIt: " + playerWhoIsIt);
    }

    void OnPhotonPlayerConnected(PhotonPlayer player)
    {
        Debug.Log("OnPhotonPlayerConnected: " + player);

        // when new players join, we send "who's it" to let them know
        // only one player will do this: the "master"

        if (PhotonNetwork.isMasterClient)
        {
            TagPlayer(playerWhoIsIt);
        }   
    }

    public static void TagPlayer(int playerID)
    {
        Debug.Log("TagPlayer: " + playerID);
        ScenePhotonView.RPC("TaggedPlayer", PhotonTargets.All, playerID);
    }

    public void TaggedPlayer(int playerID)
    {
        playerWhoIsIt = playerID;
        Debug.Log("TaggedPlayer: " + playerID);
    }

    public void OnPhotonPlayerDisconnected(PhotonPlayer player)
    {
        Debug.Log("OnPhotonPlayerDisconnected: " + player);

        if (PhotonNetwork.isMasterClient)
        {
            if (player.ID == playerWhoIsIt)
            {
                // if the player who left was "it", the "master" is the new "it"
                TagPlayer(PhotonNetwork.player.ID);
            }
        }
    }

    public void OnMasterClientSwitched()
    {
        Debug.Log("OnMasterClientSwitched");
    }


	// Update is called once per frame
	void Update () {
        if (PhotonNetwork.otherPlayers.Length == 1)
        {
            if (GameIsReady != null)
                GameIsReady();
        }
	
	}
}
