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
                    if(importantGameObjects[i].resourceObject.activeInHierarchy)
                    {
                        print(importantGameObjects[i].resourceObject.name + " is already enabled");
                        return;
                    }
                    else
                    {
                        importantGameObjects[i].resourceObject.SetActive(true);
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
                    if (!importantGameObjects[i].resourceObject.activeInHierarchy)
                    {
                        print(importantGameObjects[i].resourceObject.name + " is already enabled");
                        return;
                    }
                    else
                    {
                        importantGameObjects[i].resourceObject.SetActive(false);
                    }
                }
            }
        }
        #endregion

        #region Enable/Disable multiple GameObjects
        public void EnableGameObjects(string firstObjectName, string secondObjectName)
        {
            for(int i = 0; i < importantGameObjects.Count; i++)
            {
                if(importantGameObjects[i].resourceName == firstObjectName 
                    || importantGameObjects[i].resourceName == secondObjectName)
                {
                    if(importantGameObjects[i].resourceObject.activeInHierarchy)
                    {
                        print(importantGameObjects[i].resourceObject.name + " is already enabled");
                    }
                    else
                    {
                        importantGameObjects[i].resourceObject.SetActive(true);
                    }
                }
            }
        }
        public void EnableGameObjects(string firstObjectName, string secondObjectName, string thirdObjectName)
        {
            for (int i = 0; i < importantGameObjects.Count; i++)
            {
                if (importantGameObjects[i].resourceName == firstObjectName 
                    || importantGameObjects[i].resourceName == secondObjectName
                    || importantGameObjects[i].resourceName == thirdObjectName)
                {
                    if (importantGameObjects[i].resourceObject.activeInHierarchy)
                    {
                        print(importantGameObjects[i].resourceObject.name + " is already enabled");
                    }
                    else
                    {
                        importantGameObjects[i].resourceObject.SetActive(true);
                    }
                }
            }
        }
        public void EnableGameObjects(string firstObjectName, string secondObjectName, string thirdObjectName, string fourthObjectName)
        {
            for (int i = 0; i < importantGameObjects.Count; i++)
            {
                if (importantGameObjects[i].resourceName == firstObjectName 
                    || importantGameObjects[i].resourceName == secondObjectName
                    || importantGameObjects[i].resourceName == thirdObjectName
                    || importantGameObjects[i].resourceName == fourthObjectName)
                {
                    if (importantGameObjects[i].resourceObject.activeInHierarchy)
                    {
                        print(importantGameObjects[i].resourceObject.name + " is already enabled");
                    }
                    else
                    {
                        importantGameObjects[i].resourceObject.SetActive(true);
                    }
                }
            }
        }

        public void DisableGameObjects(string firstObjectName, string secondObjectName)
        {
            for (int i = 0; i < importantGameObjects.Count; i++)
            {
                if (importantGameObjects[i].resourceName == firstObjectName
                    || importantGameObjects[i].resourceName == secondObjectName)
                {
                    if (!importantGameObjects[i].resourceObject.activeInHierarchy)
                    {
                        print(importantGameObjects[i].resourceObject.name + " is already disabled");
                    }
                    else
                    {
                        importantGameObjects[i].resourceObject.SetActive(true);
                    }
                }
            }
        }
        public void DisableGameObjects(string firstObjectName, string secondObjectName, string thirdObjectName)
        {
            for (int i = 0; i < importantGameObjects.Count; i++)
            {
                if (importantGameObjects[i].resourceName == firstObjectName
                    || importantGameObjects[i].resourceName == secondObjectName
                    || importantGameObjects[i].resourceName == thirdObjectName)
                {
                    if (!importantGameObjects[i].resourceObject.activeInHierarchy)
                    {
                        print(importantGameObjects[i].resourceObject.name + " is already disabled");
                    }
                    else
                    {
                        importantGameObjects[i].resourceObject.SetActive(true);
                    }
                }
            }
        }
        public void DisableGameObjects(string firstObjectName, string secondObjectName, string thirdObjectName, string fourthObjectName)
        {
            for (int i = 0; i < importantGameObjects.Count; i++)
            {
                if (importantGameObjects[i].resourceName == firstObjectName
                    || importantGameObjects[i].resourceName == secondObjectName
                    || importantGameObjects[i].resourceName == thirdObjectName
                    || importantGameObjects[i].resourceName == fourthObjectName)
                {
                    if (!importantGameObjects[i].resourceObject.activeInHierarchy)
                    {
                        print(importantGameObjects[i].resourceObject.name + " is already disabled");
                    }
                    else
                    {
                        importantGameObjects[i].resourceObject.SetActive(true);
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
                    if (particleEffects[i].resourceObject.activeInHierarchy)
                    {
                        print(particleEffects[i].resourceObject.name + " is already enabled");
                        return;
                    }
                    else
                    {
                        particleEffects[i].resourceObject.SetActive(true);
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
                    if (!particleEffects[i].resourceObject.activeInHierarchy)
                    {
                        print(particleEffects[i].resourceObject.name + " is already enabled");
                        return;
                    }
                    else
                    {
                        particleEffects[i].resourceObject.SetActive(false);
                    }
                }
            }
        }
        #endregion

        #region Enable/Disable multiple Particle Systems
        public void EnableParticleSystems(string firstParticleName, string secondParticleName)
        {
            for (int i = 0; i < particleEffects.Count; i++)
            {
                if (particleEffects[i].resourceName == firstParticleName
                    || particleEffects[i].resourceName == secondParticleName)
                {
                    if (particleEffects[i].resourceObject.activeInHierarchy)
                    {
                        print(particleEffects[i].resourceObject.name + " is already enabled");
                    }
                    else
                    {
                        particleEffects[i].resourceObject.SetActive(true);
                    }
                }
            }
        }
        public void EnableParticleSystems(string firstParticleName, string secondParticleName, string thirdParticleName)
        {
            for (int i = 0; i < particleEffects.Count; i++)
            {
                if (particleEffects[i].resourceName == firstParticleName
                    || particleEffects[i].resourceName == secondParticleName
                    || particleEffects[i].resourceName == thirdParticleName)
                {
                    if (particleEffects[i].resourceObject.activeInHierarchy)
                    {
                        print(particleEffects[i].resourceObject.name + " is already enabled");
                    }
                    else
                    {
                        particleEffects[i].resourceObject.SetActive(true);
                    }
                }
            }
        }
        public void EnableParticleSystems(string firstParticleName, string secondParticleName, string thirdParticleName, string fourthParticleName)
        {
            for (int i = 0; i < particleEffects.Count; i++)
            {
                if (particleEffects[i].resourceName == firstParticleName
                    || particleEffects[i].resourceName == secondParticleName
                    || particleEffects[i].resourceName == thirdParticleName
                    || particleEffects[i].resourceName == fourthParticleName)
                {
                    if (particleEffects[i].resourceObject.activeInHierarchy)
                    {
                        print(particleEffects[i].resourceObject.name + " is already enabled");
                    }
                    else
                    {
                        particleEffects[i].resourceObject.SetActive(true);
                    }
                }
            }
        }

        public void DisableParticleSystems(string firstParticleName, string secondParticleName)
        {
            for (int i = 0; i < particleEffects.Count; i++)
            {
                if (particleEffects[i].resourceName == firstParticleName
                    || particleEffects[i].resourceName == secondParticleName)
                {
                    if (!particleEffects[i].resourceObject.activeInHierarchy)
                    {
                        print(particleEffects[i].resourceObject.name + " is already disabled");
                    }
                    else
                    {
                        particleEffects[i].resourceObject.SetActive(false);
                    }
                }
            }
        }
        public void DisableParticleSystems(string firstParticleName, string secondParticleName, string thirdParticleName)
        {
            for (int i = 0; i < particleEffects.Count; i++)
            {
                if (particleEffects[i].resourceName == firstParticleName
                    || particleEffects[i].resourceName == secondParticleName
                    || particleEffects[i].resourceName == thirdParticleName)
                {
                    if (!particleEffects[i].resourceObject.activeInHierarchy)
                    {
                        print(particleEffects[i].resourceObject.name + " is already disabled");
                    }
                    else
                    {
                        particleEffects[i].resourceObject.SetActive(false);
                    }
                }
            }
        }
        public void DisableParticleSystems(string firstSystemName, string secondSystemName, string thirdSystemName, string fourthSystemName)
        {
            for (int i = 0; i < particleEffects.Count; i++)
            {
                if (particleEffects[i].resourceName == firstSystemName
                    || particleEffects[i].resourceName == secondSystemName
                    || particleEffects[i].resourceName == thirdSystemName
                    || particleEffects[i].resourceName == fourthSystemName)
                {
                    if (!particleEffects[i].resourceObject.activeInHierarchy)
                    {
                        print(particleEffects[i].resourceObject.name + " is already disabled");
                    }
                    else
                    {
                        particleEffects[i].resourceObject.SetActive(false);
                    }
                }
            }
        }
        #endregion
    }
}
