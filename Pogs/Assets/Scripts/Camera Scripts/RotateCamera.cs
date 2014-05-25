using UnityEngine;
using System.Collections;

public class RotateCamera : MonoBehaviour {

    private bool _mouseIsClicked;

   // public GameObject cameraTarget;

    public float cameraRotateSpeed = 2f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
            if (Input.GetMouseButtonDown(1) && Input.GetKey(KeyCode.LeftShift))
                _mouseIsClicked = true;
            if (Input.GetMouseButtonUp(1))
                _mouseIsClicked = false;

            if (_mouseIsClicked)
                //transform.RotateAround(cameraTarget.transform.position, cameraTarget.transform.up, Input.GetAxis("Mouse X") * cameraRotateSpeed);     
                transform.Rotate(0, Input.GetAxis("Mouse X") * cameraRotateSpeed, 0);
	}
}
