using UnityEngine;
using Project.BaseClasses;
using Project.Managers;

public class Enemy : Character {

    public static DuckalotEvent EnemyDied;                                  //reference to the EventManager

    private void Start()
    {
        EnemyDied = EventManager.RegisterEvent("OnEnemyDied", this);        //registers the event in the EventManager
    }

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
        if(EnemyDied != null)                                               
        {
            EnemyDied.Invoke();                                             //invokes the EnemyDied event
        }
        Debug.Log("Enemy Died");
    }
    
}
