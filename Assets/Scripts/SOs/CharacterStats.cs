using UnityEngine;

namespace Project.SOs
{
    [CreateAssetMenu(fileName = "New Character Stats", menuName = "Stats/Character Stats")]
    public class CharacterStats : ScriptableObject
    {
        /// <summary>
        /// Character's name
        /// </summary>
        public string characterName = null;
        /// <summary>
        /// Character's tag
        /// </summary>
        public string characterTag = null;
        /// <summary>
        /// Character's max HP amount
        /// </summary>
        public int maxHP = 100;
        /// <summary>
        /// Character's movement speed
        /// </summary>
        public float movementSpeed = 5f;
    }
}
