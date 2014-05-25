using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JoinAttackersButtonEvents : MonoBehaviour 
{

	private dfButton _button;
    private bool canAssign;

	// Called by Unity just before any of the Update methods is called the first time.
	public void Start()
	{
        canAssign = true;
		// Obtain a reference to the dfButton instance attached to this object
		this._button = GetComponent<dfButton>();
	}

	public void OnClick( dfControl control, dfMouseEventArgs mouseEvent )
	{
		// Add event handler code here

        foreach (var player in PhotonNetwork.otherPlayers)
        {
            if (player.currentState == PhotonPlayer.State.ATTACKER)
                canAssign = false;

        }

        if (canAssign)
        {
            PhotonNetwork.player.currentState = PhotonPlayer.State.ATTACKER;
            _button.Disable();
        }
        
		Debug.Log( "Click" );
	}

}
