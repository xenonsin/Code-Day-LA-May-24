using UnityEngine;
using System.Collections;

public class TowerBlast : RangeWeapon {

    public TowerBlast()
    {
        Name = "Tits n' Pancakes";
        MinDamage = 40f;
        MaxDamage = 50f;
        AudioClipName = ""; // get bullet sounds
        Knockback = 0f;
        Range = 20.0f;
        ProjectileSpriteName = ""; 
    }
}
