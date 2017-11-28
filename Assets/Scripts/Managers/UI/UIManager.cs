using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("TEST VARIABLES")]
    public string testString = null;
    public bool testBool = false;

    [Space]

    ///<summary> Array of UIArray (script class) holding info for UI elements </summary>
    [Tooltip("Array of UIArray (script class) holding info for UI elements")]
    public UIArray[] uiElements = new UIArray[0];

    ///<summary> This instance of UIManager script </summary>
    [Tooltip("This instance of UIManager script")]
    [HideInInspector]
    public UIManager uiInstance;

    Fox.Flow.PlayerCamera playerCamera;

    void Awake()
    {
        playerCamera = FindObjectOfType<Fox.Flow.PlayerCamera>();
        #region Singleton
        if (uiInstance != null)
        {
            Debug.LogError("There are more than one instance of UIManager!");
        }
        uiInstance = this;
        #endregion
    }

    //-- TEST ONLY (probably anyway)
    void Update()
    {
        if(playerCamera.inOrbitMode == true)
        {
            TurnUIObjectOn(testString);
        }
        if(playerCamera.inOrbitMode == false)
        {
            TurnUIObjectOff(testString);
        }
    }

    ///<summary> Method enabling a UI object </summary>
    ///<param name="uiObjectName"> String specifying the UI element´s name inside of the uiElements array (array of UIArray class) </param>
    public void TurnUIObjectOn(string uiObjectName)
    {
        for(int i = 0; i < uiElements.Length; i++)
        {
            if(uiElements[i].elementName == uiObjectName)
            {
                uiElements[i].uiObject.SetActive(true);
            }
        }
    }

    ///<summary> Method disabling a UI object </summary>
    ///<param name="uiObjectName"> String specifying the UI element´s name inside of the uiElements array (array of UIArray class) </param>
    public void TurnUIObjectOff(string uiObjectName)
    {
        for (int i = 0; i < uiElements.Length; i++)
        {
            if (uiElements[i].elementName == uiObjectName)
            {
                uiElements[i].uiObject.SetActive(false);
            }
        }
    }
}
