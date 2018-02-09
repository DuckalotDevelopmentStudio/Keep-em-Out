using System.Collections.Generic;
using UnityEngine;
using Project.Managers.Properties;

namespace Project.Managers
{
    ///<summary> 
    ///Manager script that takes care of enabling/disabling UI objects with methods (HAVE TO BE IN THE uiObjects LIST). 
    ///Use when you want to enable/disable a UI object. 
    /// </summary>
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance;

        ///<summary>A list of all UI objects. Used to find objects inside of it to enable/disable.</summary> 
        public List<UIObjectProperties> uiObjects = new List<UIObjectProperties>();

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

        #region Enable/Disable one UI object
        /// <summary>Enables a single UI object</summary>
        /// <param name="objectName">Name of the UI object inside of uiObjects list</param>
        public void EnableUIObject(string objectName)
        {
            for(int i = 0; i < uiObjects.Count; i++)
            {
                if(objectName == uiObjects[i].uiName)
                {
                    if(!uiObjects[i].uiGameObject.activeInHierarchy)
                    {
                        uiObjects[i].uiGameObject.SetActive(true);
                    }
                    else
                    {
                        print(uiObjects[i].uiGameObject + " is already enabled");
                        return;
                    }
                }
            }
        }

        /// <summary>Disables a single UI object</summary>
        /// <param name="objectName">Name of the UI object inside of uiObjects list</param>
        public void DisableUIObject(string objectName)
        {
            for (int i = 0; i < uiObjects.Count; i++)
            {
                if (objectName == uiObjects[i].uiName)
                {
                    if (uiObjects[i].uiGameObject.activeInHierarchy)
                    {
                        uiObjects[i].uiGameObject.SetActive(false);
                    }
                    else
                    {
                        print(uiObjects[i].uiGameObject + " is already disabled");
                        return;
                    }
                }
            }
        }
        #endregion

        #region Enable/Disable multiple UI objects
        /// <summary>Enables multiple UI objects</summary>
        /// <param name="objectNames">String array of multiple UI object names to enable at once (HAVE TO BE THE SAME AS IN uiObjects LIST)</param>
        public void EnableUIObjects(string[] objectNames)
        {
            for(int i = 0; i < uiObjects.Count; i++)
            {
                for(int y = 0; y < objectNames.Length; y++)
                {
                    if (uiObjects[i].uiName == objectNames[y])
                    {
                        if (!uiObjects[i].uiGameObject.activeInHierarchy)
                        {
                            uiObjects[i].uiGameObject.SetActive(true);
                        }
                        else
                        {
                            print(uiObjects[i].uiGameObject + " is already enabled");
                        }
                    }
                }
            }
        }

        /// <summary>Disables multiple UI objects</summary>
        /// <param name="objectNames">String array of multiple UI object names to disable at once (HAVE TO BE THE SAME AS IN uiObjects LIST)</param>
        public void DisableUIObjects(string[] objectNames)
        {
            for (int i = 0; i < uiObjects.Count; i++)
            {
                for (int y = 0; y < objectNames.Length; y++)
                {
                    if (uiObjects[i].uiName == objectNames[y])
                    {
                        if (uiObjects[i].uiGameObject.activeInHierarchy)
                        {
                            uiObjects[i].uiGameObject.SetActive(false);
                        }
                        else
                        {
                            print(uiObjects[i].uiGameObject + " is already disabled");
                        }
                    }
                }
            }
        }
        #endregion

        #region Enable/Disable all UI objects
        /// <summary>Enables all UI objects</summary>
        public void EnableAllUIObjects()
        {
            for(int i = 0; i< uiObjects.Count; i++)
            {
                if(!uiObjects[i].uiGameObject.activeInHierarchy)
                {
                    uiObjects[i].uiGameObject.SetActive(true);
                }
                else
                {
                    print("All UI objects already enabled");
                    return;
                }
            }
        }

        /// <summary>Disables all UI objects</summary>
        public void DisableAllUIObjects()
        {
            for (int i = 0; i < uiObjects.Count; i++)
            {
                if (uiObjects[i].uiGameObject.activeInHierarchy)
                {
                    uiObjects[i].uiGameObject.SetActive(false);
                }
                else
                {
                    print("All UI objects already disabled");
                    return;
                }
            }
        }
        #endregion
    }
}
