using UnityEngine;
using System.Collections;

public abstract class Tower : MonoBehaviour, IDamagable<float>, IKillable {

    public string Name { get; set; }
    public float Health { get; set; }
    public float MaxHealth { get; set; }
    public float Height { get; set; }

    public virtual bool IsAlive { get; set; }

    public virtual void Hit(float damage)
    {
        Health -= damage;
        Debug.Log(Name + " Health: " + Health.ToString());
    }

    public virtual void Heal(float heal)
    {
        Health += heal;
        Debug.Log(Name + " Health: " + Health.ToString());
    }

    public virtual void FullHeal()
    {
        Health = MaxHealth;
        Debug.Log(Name + " Health: " + Health.ToString());
    }

    public virtual void Death()
    {
        //  this.Recycle();
    }
    public virtual void IncreaseMaxHP(float newAmount)
    {
        MaxHealth = newAmount;
    }

    public virtual void Kill()
    {
        //  this.Recycle();
    }

    public virtual void Awake()
    {
        Health = MaxHealth;
        IsAlive = true;
    }

    public virtual void Update()
    {
        if (Health <= 0)
            Death();
    }
}

