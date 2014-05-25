using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AdventureButtonEvents : MonoBehaviour 
{

	public void OnClick( dfControl control, dfMouseEventArgs mouseEvent )
	{
        Application.LoadLevel("Level One");
	}

}
