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
            if (instance != null)
            {
                Destroy(this);
            }
            instance = this;
            #endregion
        }

        #region Enable/Disable one GameObject
        /// <summary>Enables a GameObject</summary>
        /// <param name="objectNames">Name of the desired GameObject inside of the importantGameObjects List</param>
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

        /// <summary>Disables a GameObject</summary>
        /// <param name="objectNames">Name of the desired GameObject inside of the importantGameObjects List</param>
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
        /// <summary>Enables an amount of GameObjects</summary>
        /// <param name="objectNames">Names of the desired GameObjects inside of the importantGameObjects List</param>
        public void EnableGameObjects(string[] objectNames)
        {
            for(int i = 0; i < importantGameObjects.Count; i++)
            {
                for(int y = 0; y < objectNames.Length; y++)
                {
                    if (importantGameObjects[i].resourceName == objectNames[y])
                    {
                        if (!importantGameObjects[i].resourceObject.activeInHierarchy)
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
        }

        /// <summary>Disables an amount of GameObjects</summary>
        /// <param name="objectNames">Names of the desired GameObjects inside of the importantGameObjects List</param>
        public void DisableGameObjects(string[] objectNames)
        {
            for (int i = 0; i < importantGameObjects.Count; i++)
            {
                for (int y = 0; y < objectNames.Length; y++)
                {
                    if (importantGameObjects[i].resourceName == objectNames[y])
                    {
                        if (importantGameObjects[i].resourceObject.activeInHierarchy)
                        {
                            importantGameObjects[i].resourceObject.SetActive(false);
                        }
                        else
                        {
                            print(importantGameObjects[i].resourceObject.name + " is already enabled");
                        }
                    }
                }
            }
        }
        #endregion

        #region Enable/Disable one ParticleSystem
        /// <summary>Enables a ParticleSystem</summary>
        /// <param name="objectNames">Name of the desired ParticleSystem inside of the particleEffects List</param>
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

        /// <summary>Diables a ParticleSystem</summary>
        /// <param name="objectNames">Name of the desired ParticleSystem inside of the particleEffects List</param>
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
        /// <summary>Enables an amount of ParticleSystems</summary>
        /// <param name="objectNames">Names of the desired ParticleSystems inside of the particleEffects List</param>
        public void EnableParticleSystems(string[] particleNames)
        {
            for (int i = 0; i < particleEffects.Count; i++)
            {
                for (int y = 0; y < particleNames.Length; y++)
                {
                    if (importantGameObjects[i].resourceName == particleNames[y])
                    {
                        if (!particleEffects[i].resourceObject.activeInHierarchy)
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
        }

        /// <summary>Disables an amount of ParticleSystems</summary>
        /// <param name="objectNames">Names of the desired ParticleSystems inside of the particleEffects List</param>
        public void DisableParticleSystems(string[] particleNames)
        {
            for (int i = 0; i < particleEffects.Count; i++)
            {
                for (int y = 0; y < particleNames.Length; y++)
                {
                    if (importantGameObjects[i].resourceName == particleNames[y])
                    {
                        if (particleEffects[i].resourceObject.activeInHierarchy)
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
        }
        #endregion
    }
}
