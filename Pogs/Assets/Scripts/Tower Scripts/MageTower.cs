using UnityEngine;
using System.Collections;

public class MageTower : Unit {

    public string name;
    public float health;
    public float height;
    public float cost;

	// Use this for initialization
	public override void Awake () {
        Name = name;
        MaxHealth = health;
        Height = height;
        Cost = cost;
        base.Awake();
	}
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
	}

    public override void Hit(float damage)
    {
        //StartCoroutine(_spriteManager.FlashRed(0.2f));
        base.Hit(damage);
    }


    public override void Heal(float heal)
    {
        base.Heal(heal);
    }

    public override void Death()
    {
        base.Death();
    }
}
