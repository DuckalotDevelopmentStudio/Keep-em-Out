using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    public GameObject Target;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();                           //this is a reference to the NavMeshAgent
    }

    //this can be called from the wavespawner to set the target for the enemy by using EnemyMovement.SetTarget(implement a gameobject here)
    public void SetTarget(GameObject target)
    {
        Target = target;
    }

    void Update()
    {
        agent.SetDestination(Target.transform.position);                //this will set the target for the enemy so it will walk to it
    }
}
