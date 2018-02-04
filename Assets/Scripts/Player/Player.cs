using UnityEngine;
using Project.BaseClasses;
using Project.Managers;

namespace Project.Player
{
    public class Player : Character
    {
        /// <summary>
        /// Event in the EventManager
        /// </summary>
        public static DuckalotEvent PlayerDied;

        void Awake()
        {
            PlayerDied = EventManager.RegisterEvent("Player Died", this);       // Register the event inside of EventManager
        }

        void Update()
        {
            CharacterUpdateCalls();                                             // Call the update calls from Character base class
            
            if(Input.GetKeyDown(KeyCode.K))                                     // DEBUG: Kills player
            {
                Die();
                print("Debug: Kill Player");
            }
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
        }

        public override void Die()
        {
            base.Die();

            if (PlayerDied != null)                                             // Invoke the PlayerDied event
                PlayerDied.Invoke();

            Debug.LogWarning("Player died");
        }
    }
}
