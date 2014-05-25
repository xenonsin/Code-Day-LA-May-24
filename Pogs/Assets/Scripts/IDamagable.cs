using UnityEngine;
using System.Collections;

public interface IDamagable<T>{
    void Hit(T damageTaken);
    void Heal(T healAmount);
    void FullHeal();
}
