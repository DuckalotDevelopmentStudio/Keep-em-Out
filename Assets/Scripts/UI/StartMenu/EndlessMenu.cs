using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary> Main controller for the Endless Menu UI </summary>
public class EndlessMenu : MonoBehaviour
{
    ///<summary> Array wielding parameters set in the EndlessOptions class </summary>
    public EndlessOptions[] levels = new EndlessOptions[3];

    [Header("UI elements")]
    ///<summary> Reference to the LevelName UI Text element </summary>
    public Text levelName;
    ///<summary> Reference to the LevelPreview UI Image </summary>
    public Image levelPreview;
    ///<summary> Reference to the LevelDescription UI Text element </summary>
    public Text levelDescription;

    ///<summary> Integer used to switch between array elements (STARTS AT 0) Formula: Mathf.Clamp((this int), 0, levels.Length - 1) </summary>
    public int levelInfoIndex;

    void Awake()
    {        
        levelInfoIndex = Mathf.Clamp(levelInfoIndex, 0, levels.Length - 1);
    }

    void Update()
    {
        switch(levelInfoIndex)
        {
            case 0:
                levelName.text = levels[0].levelName;
                levelPreview.sprite = levels[0].levelPreview;
                levelDescription.text = levels[0].levelDescription;
                break;

            case 1:
                levelName.text = levels[1].levelName;
                levelPreview.sprite = levels[1].levelPreview;
                levelDescription.text = levels[1].levelDescription;
                break;

            case 2:
                levelName.text = levels[2].levelName;
                levelPreview.sprite = levels[2].levelPreview;
                levelDescription.text = levels[2].levelDescription;
                break;
        }
    }
}
