using UnityEngine;
using System.Collections;

public class CameraPan : MonoBehaviour {

    public bool keyboardControl;
    public float panSpeed = 2f;


    public bool mouseControl;
    public int scrollDistance = 5;

    public bool followControl;
    public GameObject player;
    //The offset of the camera to centrate the player in the X axis
    public float offsetX = -5;
    //The offset of the camera to centrate the player in the Z axis
    public float offsetZ = 0;
    //The maximum distance permited to the camera to be far from the player, its used to     make a smooth movement
    public float maximumDistance = 2;
    //The velocity of your player, used to determine que speed of the camera
    public float playerVelocity = 10;

    private float movementX;
    private float movementZ;

	// Use this for initialization

	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (keyboardControl)
            Keyboard();

        if (mouseControl)
            Mouse();

        if (followControl)
            Follow();
	
	}

    void Keyboard()
    {
        float translationX = Input.GetAxis("Horizontal");
        float translationY = Input.GetAxis("Vertical");

        translationX /= panSpeed;
        translationY /= panSpeed;
        transform.Translate(translationX + translationY, 0, translationY - translationX); 
    }

    void Mouse()
    {
        var mousePosX = Input.mousePosition.x;
        var mousePosY = Input.mousePosition.y;


        //Horizontal camera movement
        if (mousePosX < scrollDistance)
        //horizontal, left
        {
            transform.Translate(-1, 0, 1);
        }
        if (mousePosX >= Screen.width - scrollDistance)
        //horizontal, right
        {
            transform.Translate(1, 0, -1);
        }

        //Vertical camera movement
        if (mousePosY < scrollDistance)
        //scrolling down
        {
            transform.Translate(-1, 0, -1);
        }
        if (mousePosY >= Screen.height - scrollDistance)
        //scrolling up
        {
            transform.Translate(1, 0, 1);
        }
    }

    void Follow()
    {
        if (player != null)
        {
            movementX = ((player.transform.position.x + offsetX - this.transform.position.x)) / maximumDistance;
            movementZ = ((player.transform.position.z + offsetZ - this.transform.position.z)) / maximumDistance;
            this.transform.position += new Vector3((movementX * playerVelocity * Time.deltaTime), 0, (movementZ * playerVelocity * Time.deltaTime));
        }
    }
}
