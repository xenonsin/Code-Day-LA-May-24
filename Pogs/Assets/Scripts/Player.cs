using UnityEngine;
using System.Collections;

public abstract class Player : MonoBehaviour {

    public string Name { get; set; }
    public int Gold { get; set; }
    public int StartingGold { get; set; }

    public GameManager.Turns Turn { get; set; }


	// Use this for initialization
	public virtual void Awake() {
        Gold = StartingGold;
	}
	
	// Update is called once per frame
    public virtual void Update()
    {
	
	}

    public virtual void IncreaseGold(int amount)
    {
        Gold += amount;
    }

    public virtual void DecreaseGold(int amount)
    {
        Gold -= amount;
    }
}
