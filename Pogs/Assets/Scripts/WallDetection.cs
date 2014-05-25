using UnityEngine;
using System.Collections;

public class WallDetection : MonoBehaviour {


    public DefenderPlayer defender;

    public int damage;

    void OnEnable()
    {
        DefenderPlayer.DefenderReady += Initialize;
    }

    void OnDisable()
    {
        DefenderPlayer.DefenderReady -= Initialize;
    }

    void Initialize()
    {
    }

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
            DealDamageToDefender(damage);
        }
    }

    void DealDamageToDefender(int damage)
    {


        defender.DecreaseHealth(damage);


        Debug.Log(defender.health);
    }
}
