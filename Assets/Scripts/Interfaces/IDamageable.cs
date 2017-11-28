using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    float CurrentHealth { get; set; }

    float MaxHealth { get; set; }

    void Damage(float damage);

    void Die();
}
