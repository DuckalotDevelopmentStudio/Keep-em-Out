using UnityEngine;
using Project.BaseClasses;
using Project.Managers;

public class Enemy : Character {

    private void Update()
    {
        CharacterUpdateCalls();                                             //updates the enemy by using the base character class 
    }
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);                                            //takes damage by using the base character class
    }

    public override void Die()
    {
        base.Die();                                                         //dies by using the base character class
    }
}
