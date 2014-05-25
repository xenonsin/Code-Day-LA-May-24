using UnityEngine;
using System.Collections;

public class DefenderPlayer : MonoBehaviour {


    public delegate void DefenderAction();
    public static event DefenderAction GotHit;

    public delegate void DefenderDead();
    public static event DefenderDead Dead;

    public delegate void DefenderGold();
    public static event DefenderGold Gold;

    public delegate void DefenderAssigned();
    public static event DefenderAssigned DefenderReady;

    public int MaxHealth  { get; set; }
    public int health  { get; set; }
    public float gold  { get; set; }

   // public PhotonPlayer defender;

    public void IncreaseGold(float amount)
    {
        gold += amount;
        if (Gold != null)
            Gold();
    }

    public void DecreaseGold(float amount)
    {
        gold -= amount;
        if (Gold != null)
            Gold();
    }

    public void DecreaseHealth(int amount)
    {

        health -= amount;
        if (GotHit != null)
            GotHit();
    }

    public void IncreaseHealth(int amount)
    {
        health += amount;
    }

    void OnEnable()
    {
       // NetworkManager.GameIsReady += AssignDefender;
    }

    void OnDisable()
    {
        //NetworkManager.GameIsReady -= AssignDefender;
    }
    //public void AssignDefender()
    //{
    //    var temp = PhotonNetwork.playerList;

    //    foreach (var player in temp)
    //    {
    //        if (player.Name == "Defender")
    //        {
    //            defender = player;
    //            DefenderReady();
    //        }
    //    }
    //}

	// Use this for initialization
	void Awake () {
        MaxHealth = 50;
        health = 50;
        gold = 50;
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
            Dead();

        IncreaseGold(Time.deltaTime);

        if (PhotonNetwork.player.currentState == PhotonPlayer.State.DEFENDER)
        {
            if (Input.GetMouseButtonDown(0) && gold >= 10f)
            {

                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag == "Build")
                    {
                        DecreaseGold(10);
                        var position = new Vector3(hit.point.x, 0, hit.point.z);

                        PhotonNetwork.Instantiate("Tower", position, Quaternion.Euler(-90f, 0f,0f),0);
                    }

                }
            }
        }
	
	}
}
