using UnityEngine;
using System.Collections;

public class Monster : Unit{

    public delegate void WolfDealth();
    public static event WolfDealth Dead;

    public string monsterName;
    public float health;
    public float height;

    private WolfSpriteManager _spriteManager;
    // Use this for initialization
    public override void Awake()
    {
        _spriteManager = this.GetComponent<WolfSpriteManager>();
        Name = monsterName;
        MaxHealth = health;
        Height = height;
        base.Awake();


    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

    }


    public override void Hit(float damage)
    {
        StartCoroutine(_spriteManager.FlashRed(0.2f));
        base.Hit(damage);


        // _animator.SetTrigger("Hit");

        //instantiate floating numbers
        //flash red
    }


    public override void Heal(float heal)
    {
        base.Heal(heal);
    }

    public override void Death()
    {
        if (Dead != null)
            Dead();
        base.Death();

    }
}
