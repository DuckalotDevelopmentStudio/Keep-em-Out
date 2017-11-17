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
            if (instance != this)
            {
                print("More than one instance of " + this + ". （╯ ͡°  ل͜ ͡°）╯︵ ┻━┻");
            }
            instance = this;
            #endregion
        }

        #region Enable/Disable one UI object
        /// <summary>Enables a single UI object.</summary>
        /// <param name="uiName">Name of the UI object inside of the uiObjects list.</param>
        public void EnableUIObject(string uiName)
        {
            for(int i = 0; i < uiObjects.Count; i++)
            {
                if(uiName == uiObjects[i].uiName)
                {
                    if(uiObjects[i].uiGameObject.activeInHierarchy)
                    {
                        print(uiObjects[i].uiGameObject + " is already enabled");
                        return;
                    }
                    else
                    {
                        uiObjects[i].uiGameObject.SetActive(true);
                    }
                }
            }
        }

        /// <summary>Disables a single UI object.</summary>
        /// <param name="uiName">Name of the UI object inside of the uiObjects list.</param>
        public void DisableUIObject(string uiName)
        {
            for (int i = 0; i < uiObjects.Count; i++)
            {
                if (uiName == uiObjects[i].uiName)
                {
                    if (!uiObjects[i].uiGameObject.activeInHierarchy)
                    {
                        print(uiObjects[i].uiGameObject + " is already disabled");
                        return;
                    }
                    else
                    {
                        uiObjects[i].uiGameObject.SetActive(false);
                    }
                }
            }
        }
        #endregion

        #region Enable/Disable multiple UI objects
        /// <summary>Enables two UI objects.</summary>
        /// <param name="uiNameOne">Name of the first UI object inside of uiObjects list</param>
        /// <param name="uiNameTwo">Name of the second UI object inside of uiObjects list</param>
        public void EnableUIObjects(string uiNameOne, string uiNameTwo)
        {
            for(int i = 0; i < uiObjects.Count; i++)
            {
                if(uiObjects[i].uiName == uiNameOne 
                    || uiObjects[i].uiName == uiNameTwo)
                {
                    if(uiObjects[i].uiGameObject.activeInHierarchy)
                    {
                        print(uiObjects[i].uiGameObject + " is already enabled");
                    }
                    else
                    {
                        uiObjects[i].uiGameObject.SetActive(true);
                    }
                }
            }
        }
        /// <summary>Enables three UI objects.</summary>
        /// <param name="uiNameOne">Name of the first UI object inside of uiObjects list</param>
        /// <param name="uiNameTwo">Name of the second UI object inside of uiObjects list</param>
        /// <param name="uiNameThree">Name of the third UI object inside of uiObjects list</param>
        public void EnableUIObjects(string uiNameOne, string uiNameTwo, string uiNameThree)
        {
            for (int i = 0; i < uiObjects.Count; i++)
            {
                if (uiObjects[i].uiName == uiNameOne 
                    || uiObjects[i].uiName == uiNameTwo 
                    || uiObjects[i].uiName == uiNameThree)
                {
                    if (uiObjects[i].uiGameObject.activeInHierarchy)
                    {
                        print(uiObjects[i].uiGameObject + " is already enabled");
                    }
                    else
                    {
                        uiObjects[i].uiGameObject.SetActive(true);
                    }
                }
            }
        }
        /// <summary>Enables four UI objects.</summary>
        /// <param name="uiNameOne">Name of the first UI object inside of uiObjects list</param>
        /// <param name="uiNameTwo">Name of the second UI object inside of uiObjects list</param>
        /// <param name="uiNameThree">Name of the third UI object inside of uiObjects list</param>
        /// <param name="uiNameFour">Name of the fourth UI object inside of uiObjects list</param>
        public void EnableUIObjects(string uiNameOne, string uiNameTwo, string uiNameThree, string uiNameFour)
        {
            for (int i = 0; i < uiObjects.Count; i++)
            {
                if (uiObjects[i].uiName == uiNameOne 
                    || uiObjects[i].uiName == uiNameTwo 
                    || uiObjects[i].uiName == uiNameThree 
                    || uiObjects[i].uiName == uiNameFour)
                {
                    if (uiObjects[i].uiGameObject.activeInHierarchy)
                    {
                        print(uiObjects[i].uiGameObject + " is already enabled");
                    }
                    else
                    {
                        uiObjects[i].uiGameObject.SetActive(true);
                    }
                }
            }
        }

        /// <summary>Disables two UI objects.</summary>
        /// <param name="uiNameOne">Name of the first UI object inside of uiObjects list</param>
        /// <param name="uiNameTwo">Name of the second UI object inside of uiObjects list</param>
        public void DisableUIObjects(string uiNameOne, string uiNameTwo)
        {
            for (int i = 0; i < uiObjects.Count; i++)
            {
                if (uiObjects[i].uiName == uiNameOne
                    || uiObjects[i].uiName == uiNameTwo)
                {
                    if (!uiObjects[i].uiGameObject.activeInHierarchy)
                    {
                        print(uiObjects[i].uiGameObject + " is already disabled");
                    }
                    else
                    {
                        uiObjects[i].uiGameObject.SetActive(false);
                    }
                }
            }
        }
        /// <summary>Disables three UI objects.</summary>
        /// <param name="uiNameOne">Name of the first UI object inside of uiObjects list</param>
        /// <param name="uiNameTwo">Name of the second UI object inside of uiObjects list</param>
        /// <param name="uiNameThree">Name of the third UI object inside of uiObjects list</param>
        public void DisableUIObjects(string uiNameOne, string uiNameTwo, string uiNameThree)
        {
            for (int i = 0; i < uiObjects.Count; i++)
            {
                if (uiObjects[i].uiName == uiNameOne
                    || uiObjects[i].uiName == uiNameTwo
                    || uiObjects[i].uiName == uiNameThree)
                {
                    if (!uiObjects[i].uiGameObject.activeInHierarchy)
                    {
                        print(uiObjects[i].uiGameObject + " is already disabled");
                    }
                    else
                    {
                        uiObjects[i].uiGameObject.SetActive(false);
                    }
                }
            }
        }
        /// <summary>Disables four UI objects.</summary>
        /// <param name="uiNameOne">Name of the first UI object inside of uiObjects list</param>
        /// <param name="uiNameTwo">Name of the second UI object inside of uiObjects list</param>
        /// <param name="uiNameThree">Name of the third UI object inside of uiObjects list</param>
        /// <param name="uiNameFour">Name of the fourth UI object inside of uiObjects list</param>
        public void DisableUIObjects(string uiNameOne, string uiNameTwo, string uiNameThree, string uiNameFour)
        {
            for (int i = 0; i < uiObjects.Count; i++)
            {
                if (uiObjects[i].uiName == uiNameOne
                    || uiObjects[i].uiName == uiNameTwo
                    || uiObjects[i].uiName == uiNameThree
                    || uiObjects[i].uiName == uiNameFour)
                {
                    if (!uiObjects[i].uiGameObject.activeInHierarchy)
                    {
                        print(uiObjects[i].uiGameObject + " is already disabled");
                    }
                    else
                    {
                        uiObjects[i].uiGameObject.SetActive(false);
                    }
                }
            }
        }
        #endregion

        #region Enable/Disable all UI objects
        /// <summary>Enables all UI objects.</summary>
        public void EnableAllUIObjects()
        {
            for(int i = 0; i< uiObjects.Count; i++)
            {
                if(uiObjects[i].uiGameObject.activeInHierarchy)
                {
                    print("All UI objects already enabled");
                    return;
                }
                else
                {
                    uiObjects[i].uiGameObject.SetActive(true);
                }
            }
        }

        /// <summary>Disables all UI objects.</summary>
        public void DisableAllUIObjects(string uiName)
        {
            for (int i = 0; i < uiObjects.Count; i++)
            {
                if (!uiObjects[i].uiGameObject.activeInHierarchy)
                {
                    print("All UI objects already disabled");
                    return;
                }
                else
                {
                    uiObjects[i].uiGameObject.SetActive(false);
                }
            }
        }
        #endregion
    }
}
