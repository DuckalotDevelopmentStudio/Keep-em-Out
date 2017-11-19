using System.Collections.Generic;
using UnityEngine;
using Project.Managers.Properties;

namespace Project.Managers
{
    /// <summary>Keeps track of all important objects</summary>
    public class ResourceManager : MonoBehaviour
    {
        public static ResourceManager instance;

        /// <summary>List holding all important GameObjects</summary>
        public List<ResourceProperties> importantGameObjects = new List<ResourceProperties>();
        /// <summary>List holding all particles</summary>
        public List<ResourceProperties> particleEffects = new List<ResourceProperties>();

        void Awake()
        {
            #region Singleton
            if (instance != this)
            {
                print("More than one instance of " + this + ". （╯ ͡°  ل͜ ͡°）╯︵ ┻━┻");
            }
            instance = this;
            #endregion
        }

        #region Enable/Disable one GameObject
        public void EnableGameObject(string objectName)
        {
            for(int i = 0; i < importantGameObjects.Count; i++)
            {
                if(importantGameObjects[i].resourceName == objectName)
                {
                    if(!importantGameObjects[i].resourceObject.activeInHierarchy)
                    {
                        importantGameObjects[i].resourceObject.SetActive(true);
                    }
                    else
                    {
                        print(importantGameObjects[i].resourceObject.name + " is already enabled");
                        return;
                    }
                }
            }
        }

        public void DisableGameObject(string objectName)
        {
            for (int i = 0; i < importantGameObjects.Count; i++)
            {
                if (importantGameObjects[i].resourceName == objectName)
                {
                    if (importantGameObjects[i].resourceObject.activeInHierarchy)
                    {
                        importantGameObjects[i].resourceObject.SetActive(false);
                    }
                    else
                    {
                        print(importantGameObjects[i].resourceObject.name + " is already enabled");
                        return;
                    }
                }
            }
        }
        #endregion

        #region Enable/Disable multiple GameObjects
        public void EnableGameObjects(string[] objectNames)
        {
            for(int i = 0; i < importantGameObjects.Count; i++)
            {
                if(importantGameObjects[i].resourceName == objectNames[i])
                {
                    if(importantGameObjects[i].resourceObject.activeInHierarchy)
                    {
                        importantGameObjects[i].resourceObject.SetActive(true);
                    }
                    else
                    {
                        print(importantGameObjects[i].resourceObject.name + " is already enabled");
                    }
                }
            }
        }

        public void DisableGameObjects(string[] objectNames)
        {
            for (int i = 0; i < importantGameObjects.Count; i++)
            {
                if (importantGameObjects[i].resourceName == objectNames[i])
                {
                    if (importantGameObjects[i].resourceObject.activeInHierarchy)
                    {
                        importantGameObjects[i].resourceObject.SetActive(false);
                    }
                    else
                    {
                        print(importantGameObjects[i].resourceObject.name + " is already disabled");
                    }
                }
            }
        }
        #endregion

        #region Enable/Disable one ParticleSystem
        public void EnableParticleSystem(string particleName)
        {
            for (int i = 0; i < particleEffects.Count; i++)
            {
                if (particleEffects[i].resourceName == particleName)
                {
                    if (!particleEffects[i].resourceObject.activeInHierarchy)
                    {
                        particleEffects[i].resourceObject.SetActive(true);
                    }
                    else
                    {
                        print(particleEffects[i].resourceObject.name + " is already enabled");
                        return;
                    }
                }
            }
        }

        public void DisableParticleSystem(string particleName)
        {
            for (int i = 0; i < particleEffects.Count; i++)
            {
                if (particleEffects[i].resourceName == particleName)
                {
                    if (particleEffects[i].resourceObject.activeInHierarchy)
                    {
                        particleEffects[i].resourceObject.SetActive(false);
                    }
                    else
                    {
                        print(particleEffects[i].resourceObject.name + " is already enabled");
                        return;
                    }
                }
            }
        }
        #endregion

        #region Enable/Disable multiple Particle Systems
        public void EnableParticleSystems(string[] particleNames)
        {
            for (int i = 0; i < particleEffects.Count; i++)
            {
                if (particleEffects[i].resourceName == particleNames[i])
                {
                    if (!particleEffects[i].resourceObject.activeInHierarchy)
                    {
                        particleEffects[i].resourceObject.SetActive(true);
                    }
                    else
                    {
                        print(particleEffects[i].resourceObject.name + " is already enabled");
                    }
                }
            }
        }

        public void DisableParticleSystems(string[] particleNames)
        {
            for (int i = 0; i < particleEffects.Count; i++)
            {
                if (particleEffects[i].resourceName == particleNames[i])
                {
                    if (!particleEffects[i].resourceObject.activeInHierarchy)
                    {
                        particleEffects[i].resourceObject.SetActive(false);
                    }
                    else
                    {
                        print(particleEffects[i].resourceObject.name + " is already disabled");
                    }
                }
            }
        }
        #endregion
    }
}
