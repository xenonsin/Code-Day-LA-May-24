using UnityEngine;
using System.Collections;

public class AttackerPlayer : MonoBehaviour {

    public delegate void AttackerAssigned();
    public static event AttackerAssigned AttackerReady;

    public int health = 1;
    public int gold = 50;

    public void IncreaseGold(int amount)
    {
        gold += amount;
    }

    public void DecreaseGold(int amount)
    {
        gold -= amount;
    }

    public void DecreaseHealth(int amount)
    {
        health -= amount;
    }

    public void IncreaseHealth(int amount)
    {
        health += amount;
    }
       

    public Monster wolf;

    private Transform _castle;

    public PhotonPlayer attacker;

    void OnEnable()
    {
       // NetworkManager.GameIsReady += AssignAttacker;
    }

    void OnDisable()
    {
      //  NetworkManager.GameIsReady -= AssignAttacker;
    }
    //public void AssignAttacker()
    //{
    //    var temp = PhotonNetwork.playerList;

    //    foreach (var player in temp)
    //    {
    //        if (player.Name == "Attacker")
    //        {
    //            attacker = player;
    //            AttackerReady();
    //        }
    //    }
    //}

	// Use this for initialization
	void Start () {
        _castle = GameObject.FindGameObjectWithTag("Castle").transform;
	
	}
	
	// Update is called once per frame
	void Update () {
        if (PhotonNetwork.player.currentState == PhotonPlayer.State.ATTACKER)
        {
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
                        PhotonNetwork.Instantiate("Wolf", position, Quaternion.identity, 0);
                    }

                }
            }
        }
	
	}
}
