using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChoiceEvents : MonoBehaviour 
{

	private dfPanel _panel;


    public void OnEnable()
    {
        NetworkManager.GameIsReady += Hide;
    }

    public void OnDisable()
    {
        NetworkManager.GameIsReady -= Hide;
    }

    public void Hide()
    {
        _panel.Hide();
    }
	// Called by Unity just before any of the Update methods is called the first time.
	public void Start()
	{
		// Obtain a reference to the dfPanel instance attached to this object
		this._panel = GetComponent<dfPanel>();
	}

    public void Update()
    {
        var playerList = PhotonNetwork.playerList;
    }


}
