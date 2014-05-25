using UnityEngine;
using System.Collections;

public abstract class BaseWeapon {

    public string Name { get; set; }
    public float MinDamage { get; set; }
    public float MaxDamage { get; set; }
    public float Knockback { get; set; }
    public string AudioClipName { get; set; }
    public float Range { get; set; }
    //public string SpriteName{ get; set;}


	
}
