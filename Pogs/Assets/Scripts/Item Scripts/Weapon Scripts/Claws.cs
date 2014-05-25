using UnityEngine;
using System.Collections;

public class Claws : MeleeWeapon
{

	public Claws()
    {
        Name = "grr";
        MinDamage = 5f;
        MaxDamage = 10f;
        AudioClipName = "attack1";
        Range = 6.0f;
        Knockback = 5f;
        Delay = 1f;
        Angle = 70f;
        Magnitude = 0.1f;
        ShakeDuration = 0.3f;
        ShakeSpeed = 5.0f;
    }

    public Claws(float minDamage, float maxDamage, float range, float angle, float magnitude)
    {
        MinDamage = minDamage;
        MaxDamage = maxDamage;
        Range = range;
        Angle = angle;
        Magnitude = magnitude;
        Name = "grr";
        AudioClipName = "attack1";
        Knockback = 5f;
        Delay = 1f;
        ShakeDuration = 0.3f;
        ShakeSpeed = 5.0f;
    }
}
