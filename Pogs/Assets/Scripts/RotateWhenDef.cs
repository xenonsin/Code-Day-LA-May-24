using UnityEngine;
using System.Collections;

public class RotateWhenDef : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void CameraDefRotate()
    {
        transform.localRotation = new Quaternion(0f, 90f, 0f,0f);
    }
}
