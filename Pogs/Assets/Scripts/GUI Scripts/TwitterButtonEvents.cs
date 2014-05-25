using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TwitterButtonEvents : MonoBehaviour 
{

	public void OnClick( dfControl control, dfMouseEventArgs mouseEvent )
	{
        Application.OpenURL("https://twitter.com/KISanPablo");
	}

}
