using UnityEngine;

namespace Project.BaseClases
{
    public class Character : MonoBehaviour
    {        
        protected void CharacterUpdateCalls()                   /// <summary>Contains all the base class' UpdateCalls (call inside of Update() of a derived class)</summary>
        {
            //-- Destroy gameObject if currentHP <= 0
        }

        public virtual void TakeDamage(int damage)              /// <summary>Subtracts damage from the character's current HP</summary> <param name="damage">Desired amount of damage to subtract</param>
        {
            //-- Subtract damage from current HP
        }

        public virtual void Die()                               /// <summary>Destroys the character</summary>
        {
            Destroy(gameObject);
        }
    }
}
