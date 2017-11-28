using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    string enemyName = "";
    float currentHealth = 100;
    float MaxHealth = 100;

    List<WallHealth> WallList = new List<WallHealth>();
    List<WallHealth> sortedWallList = new List<WallHealth>();

    WallHealth previousWallHealth;


    public virtual void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
        if (currentHealth <= 0)
        {
            //Kill enemy
            //Update GUI for enemy

            currentHealth = 0;
        }
    }

    public virtual void EnemyDie()
    {
        //Play Death Animation
        //Play Death Sound
        //Give Score to player?
    }

    public virtual void AIAttackWall()
    {
        //Find the lowest health wall and attack it, can easily change later
        WallHealth[] walls = FindObjectsOfType<WallHealth>();


        foreach (WallHealth w in walls)
        {
            WallList.Add(w);
        }

        foreach (WallHealth w in WallList)
        {
            if (w.CurrentHealth <= previousWallHealth.CurrentHealth)
            {
                sortedWallList.Insert(0, w);
            }
        }

    }

    public virtual void DamageWall(float dmg)
    {

    }
}
