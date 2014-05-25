using UnityEngine;
using System.Collections;

public class Scythe : MeleeWeapon {

    public Scythe()
    {
        Name = "ol' Reliable";
        MinDamage = 200f;
        MaxDamage = 300f;
        AudioClipName = "attack1";
        Knockback = 7f;
        Range = 5.0f;
        Delay = 0.5f;
        Angle = 40f;
        Magnitude = 0.2f;
        ShakeDuration = 0.4f;
        ShakeSpeed = 5.0f;
    }

    public Scythe(string name, float minDamage, float maxDamage)
    {
        Name = name;
        MinDamage = minDamage;
        MaxDamage = maxDamage;
        AudioClipName = "attack1";
        Range = 5f;
        Knockback = 7f;
        Range = 5.0f;
        Delay = 0.5f;
        Angle = 40f;
        Magnitude = 0.2f;
        ShakeDuration = 0.3f;
        ShakeSpeed = 5.0f;
    }

    public Scythe(string name, string audioClipName, float minDamage, float maxDamage, float radius, float knockback, float distance, float delay, float angle, float magnitude, float shakeDuration, float shakeSpeed)
    {
        Name = name;
        AudioClipName = audioClipName;
        MinDamage = minDamage;
        MaxDamage = maxDamage;
        Range = radius;
        Knockback = knockback;
        Range = distance;
        Delay = delay;
        Angle = angle;
        Magnitude = magnitude;
        ShakeDuration = shakeDuration;
        ShakeSpeed = shakeSpeed;

    }
    


}
