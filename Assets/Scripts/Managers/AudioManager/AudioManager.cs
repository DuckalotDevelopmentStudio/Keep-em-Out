using System.Collections.Generic;
using UnityEngine;
using Project.Managers.Properties;

namespace Project.Managers
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance;

        public List<AudioProperties> audioClips = new List<AudioProperties>();

        void Awake()
        {
            #region Singleton
            if(instance != null)
            {
                Destroy(this);
            }
            instance = this;
            #endregion

            foreach(AudioProperties sound in audioClips)
            {
                gameObject.AddComponent<AudioSource>();
            }
        }

        public void PlayClip(GameObject soundObject, string clipName)
        {
            for(int i = 0; i < audioClips.Count; i++)
            {
                if(clipName == audioClips[i].audioName)
                {
                    AudioSource source;

                    source = soundObject.GetComponent<AudioSource>();

                    source.clip = audioClips[i].audioClip;
                    source.volume = audioClips[i].volume;
                    source.pitch = audioClips[i].pitch;
                    source.loop = audioClips[i].loop;
                }
            }
        }
    }
}
