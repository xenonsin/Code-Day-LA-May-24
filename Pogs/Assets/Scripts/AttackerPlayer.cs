using UnityEngine;
using System.Collections;

public class AttackerPlayer : MonoBehaviour {

    public Monster wolf;

    private Transform _castle;

	// Use this for initialization
	void Start () {
        _castle = GameObject.FindGameObjectWithTag("Castle").transform;
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Attacker Spawn")
                {
                    var position = new Vector3(hit.point.x, 0, hit.point.z);

                    var wolfs = wolf.GetComponent<WolfFollow>();
                    wolfs.target = _castle;
                    Instantiate(wolf, position, Quaternion.identity);
                }
            
            }
        }
	
	}
}
