using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UIArray
{
    ///<summary> String naming the array element </summary>
    [Tooltip("String naming the array element")]
    public string elementName = null;

    ///<summary> Reference to the UI´s Game Object </summary>
    [Tooltip("Reference to the UI´s Game Object")]
    public GameObject uiObject;
}
