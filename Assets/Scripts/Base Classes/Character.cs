using UnityEngine;
using Project.SOs;

namespace Project.BaseClasses
{
    ///<summary>
    ///Base class for all characters
    ///</summary>
    public class Character : MonoBehaviour
    {
        /// <summary>
        /// CharacterStats SO
        /// </summary>
        public CharacterStats charStats = null;

        /// <summary>
        /// Character's current HP amount
        /// </summary>
        public int currentHP = 0;

        void Start()
        {
            if (!charStats)
                charStats = ScriptableObject.CreateInstance<CharacterStats>();

            currentHP = charStats.maxHP;
        }

        ///<summary>
        ///Contains all the base class' UpdateCalls (call inside of Update() of a derived class)
        ///</summary>
        protected void CharacterUpdateCalls()
        {
            if (charStats.maxHP <= 0)
                Die();
        }

        /// <summary>
        /// Subtracts damage from the character's current HP
        /// </summary> 
        /// <param name="damage">
        /// Desired amount of damage to subtract
        /// </param>
        public virtual void TakeDamage(int damage)
        {
            currentHP -= damage;
        }

        /// <summary>
        /// Destroys the character
        /// </summary>
        public virtual void Die()
        {
            Destroy(gameObject);
        }
    }
}
