using UnityEngine;

namespace Project.Managers.Properties
{
    [System.Serializable]
    public class AudioProperties
    {
        public string audioName = null;
        public AudioClip audioClip = null;
        public bool loop = false;
        [Range(0,1)]
        public float volume;
        [Range(-3,3)]
        public float pitch;

        void Awake()
        {
            volume = Mathf.Clamp(volume, 0, 1);
        }
    }
}
