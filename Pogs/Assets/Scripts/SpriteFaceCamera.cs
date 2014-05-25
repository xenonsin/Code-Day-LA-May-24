using UnityEngine;
using System.Collections;

public class SpriteFaceCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        var moveDirection = Camera.main.transform.forward;
        moveDirection.y = 0;

        transform.forward = moveDirection;
	
	}
}
