using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LobbyEvents : MonoBehaviour 
{

	private dfScrollPanel _scrollPanel;

	// Called by Unity just before any of the Update methods is called the first time.
	public void Start()
	{
		// Obtain a reference to the dfScrollPanel instance attached to this object
		this._scrollPanel = GetComponent<dfScrollPanel>();
	}


}
