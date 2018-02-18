using UnityEngine;
using UnityEngine.AI;

namespace Project.Enemy
{
    [RequireComponent(typeof(Enemy), typeof(NavMeshAgent))]
    public class EnemyMovement : MonoBehaviour
    {
        private Enemy en;

        /// <summary>
        /// Transform component of the enemy's target
        /// </summary>
        public Transform target;

        private NavMeshAgent agent;

        void Start()
        {
            en = GetComponent<Enemy>();                                     // Reference to the Enemy script
            agent = GetComponent<NavMeshAgent>();                           //this is a reference to the NavMeshAgent
        }

        void Update()
        {
            agent.SetDestination(target.position * en.charStats.movementSpeed);         //this will set the target for the enemy so it will walk to it
        }

        /// <summary>
        /// Sets the Enemy's target to move to
        /// </summary>
        /// <param name="targetsTransform">Transform of the target</param>
        public void SetTarget(Transform targetsTransform)
        {
            target = targetsTransform;
        }
    }
}
