using UnityEngine;
using System.Collections;

public class DualPistols : RangeWeapon {

	public DualPistols()
    {
        Name = "Tits n' Pancakes";
        MinDamage = 40f;
        MaxDamage = 50f;
        AudioClipName = "attack1"; // get bullet sounds
        Knockback = 7f;
        Range = 20.0f;
    }
}
