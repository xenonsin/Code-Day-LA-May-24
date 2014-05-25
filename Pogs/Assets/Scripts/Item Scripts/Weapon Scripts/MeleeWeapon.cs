using UnityEngine;
using System.Collections;

public class MeleeWeapon: BaseWeapon {

    public float Delay { get; set; }
    public float Angle { get; set; }
    public float Magnitude { get; set; }
    public float ShakeDuration { get; set; }
    public float ShakeSpeed { get; set; }

    /*
    public MeleeWeapon(string name, float radius, float knockback, float distance, float delay, float angle, float magnitude, float shakeDuration, float shakeSpeed)
    {
        Name = name;
        Radius = radius;
        Knockback = knockback;
        Distance = distance;
        Delay = delay;
        Angle = angle;
        Magnitude = magnitude;
        ShakeDuration = shakeDuration;
        ShakeSpeed = shakeSpeed;

    }*/


}
