using UnityEngine;
using Project.Managers;


namespace Project.other
{
    [RequireComponent(typeof(Collider))]
    public class TriggerArea : MonoBehaviour
    {

        private Collider collider;

        public GameMaster gameMaster;

        public bool AllTags;
        public string Tag;

        void Start()
        {
            // Get the collider and make sure it becomes a trigger
            collider = GetComponent<Collider>();
            collider.isTrigger = true;

            AllTags = false;
            Tag = "Player";
        }


        private void OnTriggerEnter(Collider other)
        {
            if (AllTags)
            {
                Trigger(other);
            }
            else if(other.tag == Tag)
            {
                Trigger(other);
            }       
        }

        private void Trigger(Collider other)
        {
            Debug.Log(other.name + " went inside the trigger area!");
            gameMaster.SwitchGameState(GameState.GameOver);
        }

    }

}
