using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour, IDamageable
{
    /// <summary>
    /// CJ
    /// Base class for all the enemy ai to be inherited from
    /// </summary>

    public List<WallHealth> WallHealthList = new List<WallHealth>();
    public GameObject TargetToAttack;
    protected NavMeshAgent enemyAgent;
    public float RateOfFire = 1;
    protected float DPSTimer = 1;
    protected float currentHealth;
    protected float maxHealth = 100;


    public float CurrentHealth
    {
        get
        {
            return currentHealth;
        }

        set
        {
            currentHealth = value;
        }
    }
    public float MaxHealth
    {
        get
        {
            return maxHealth;
        }
        set
        {
            maxHealth = value;
        }
    }

    [SerializeField]
    protected AIState aiState;
    public enum AIState
    {
        Seek, MoveToTarget, Attack, NoTargetsLeft
    }
    public AIState aiStateProperty
    {
        get
        {
            return aiState;
        }
        set
        {
            aiState = value;

            if (aiState == AIState.Seek)
            {
                SeekTarget();
            }

            if (aiState == AIState.MoveToTarget)
            {
                MoveToTarget();
            }

            if (aiState == AIState.Attack)
            {
                AttackTarget();
            }

            if (aiState == AIState.NoTargetsLeft)
            {
                NoTargetsLeft();
            }
        }
    }
    private bool pauseAI;

    public bool PauseAI
    {
        get { return pauseAI; }
        set { pauseAI = value;
            if (pauseAI)
            {
                StopAllCoroutines();
                GetComponent<NavMeshAgent>().SetDestination(transform.position);
            }
            else
            {               
                StartCoroutine(AILoop());
            }

        }
    }

    private void Start()
    {
        
    }


    /// <summary>
    /// CJ
    /// Finds the closest Wall To attack and then moves toward it and 
    /// attacks it based on rate of fire;
    /// </summary>
    public virtual void SeekTarget()
    {
        if (Fox.Flow.PlayerCamera.m_Instance.inOrbitMode)
        {
            PauseAI = true;
        }

        WallHealthList.Clear();

        WallHealth[] wallHealthArray = FindObjectsOfType<WallHealth>();

        if (wallHealthArray.Length > 0)
        {
            WallHealthList.Clear();
            WallHealthList.AddRange(wallHealthArray);
            WallHealthList.Sort(delegate (WallHealth x, WallHealth y)
            {
                return Vector3.Distance(enemyAgent.transform.position, x.transform.position).CompareTo(Vector3.Distance(enemyAgent.transform.position, y.transform.position));
            });

            TargetToAttack = WallHealthList[0].gameObject;

            MoveToTarget();
        }
        else
        {
            aiStateProperty = AIState.NoTargetsLeft;
        }
    }

    public virtual void MoveToTarget()
    {
        enemyAgent.ResetPath();
        enemyAgent.SetDestination(WallHealthList[0].transform.position);
    }

    public virtual void AttackTarget()
    {

    }

    public virtual void NoTargetsLeft()
    {

    }

    public virtual IEnumerator AILoop()
    {
        yield return 0;
    }

    // Use this for initialization
    void Awake()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        CurrentHealth = MaxHealth;

    }

    public void Damage(float damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

}
