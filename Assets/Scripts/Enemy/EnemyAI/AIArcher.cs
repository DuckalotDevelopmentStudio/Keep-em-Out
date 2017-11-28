using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIArcher : AIEnemy
{
    /// <summary>
    /// CJ
    /// Archer Class, Shoots Ranged Projectiles (Arrows)
    /// </summary>

    public float BowDamage = 20;
    public float EnemyRange = 20f;

    Coroutine AILoopRoutine;

    private void Start()
    {
        WallHealth[] walls = FindObjectsOfType<WallHealth>();
        
        if (walls.Length < 1)
        {
            aiStateProperty = AIState.NoTargetsLeft;
            return;
        }
        //print(walls.Length);
        AILoopRoutine = StartCoroutine(AILoop());
    }

    private void Update()
    {

    }

    public override void MoveToTarget()
    {
        base.MoveToTarget();
        base.enemyAgent.stoppingDistance = EnemyRange;           
    }

    public override void AttackTarget()
    {
        base.WallHealthList[0].CurrentHealth -= BowDamage;
    }

    public override IEnumerator AILoop()
    {

        while (aiStateProperty != AIState.NoTargetsLeft)
        {
            yield return new WaitForEndOfFrame();

            base.SeekTarget();

            while (Vector3.Distance(transform.position,enemyAgent.destination) >= base.enemyAgent.stoppingDistance + 1)
            {
                
                yield return new WaitForEndOfFrame();
            }

            while(base.WallHealthList[0].CurrentHealth > 0)
            {
                AttackTarget();
                yield return new WaitForSeconds(RateOfFire);
            }

            base.WallHealthList[0].transform.root.gameObject.SetActive(false);

            yield return new WaitForSeconds(RateOfFire);
            base.SeekTarget();
        }
    }

}
