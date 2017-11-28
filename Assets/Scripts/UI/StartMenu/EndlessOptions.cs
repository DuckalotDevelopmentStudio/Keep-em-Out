using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
///<summary> Class with parameters for the Endless Menu UI elements. </summary>
public class EndlessOptions
{
    ///<summary> Level´s name (UI TEXT ONLY) </summary>
    public string levelName;

    ///<summary> Level´s preview picture (SPRITE) </summary>
    public Sprite levelPreview;

    [TextArea(2,5)]
    ///<summary> Level´s description (UI TEXT ONLY) </summary>
    public string levelDescription;
}
