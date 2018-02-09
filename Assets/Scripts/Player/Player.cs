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

		// MAke sure register your event when all actions in the EventManager are done! so i set the Manager GameObject in the Hierarchy to the top to run at first
        void Awake()
        {
			PlayerDied = EventManager.RegisterEvent("OnPLayerDied", this);      // Register the event inside of EventManager
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
