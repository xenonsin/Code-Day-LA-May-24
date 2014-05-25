using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GoldEvents : MonoBehaviour 
{
    public DefenderPlayer defender;
    public AttackerPlayer attacker;

	private dfLabel _label;
    private bool game;

    void OnEnable()
    {
        NetworkManager.GameIsReady += Initialize;
    }

    void OnDisable()
    {
        NetworkManager.GameIsReady -= Initialize;
    }

    public void Initialize()
    {
        game = true;
    }

	// Called by Unity just before any of the Update methods is called the first time.
	public void Start()
	{
		// Obtain a reference to the dfLabel instance attached to this object
		this._label = GetComponent<dfLabel>();
	}

    public void Update()
    {
        if (game)
        {
            float number = 0;
            if (PhotonNetwork.player.currentState == PhotonPlayer.State.ATTACKER)
            {
                number = attacker.gold;
            }
            else if (PhotonNetwork.player.currentState == PhotonPlayer.State.DEFENDER)
            {
                number = defender.gold;
            }

            int temp = (int)number;
            this._label.Text = "Gold: " + temp;
        }
    }


}
