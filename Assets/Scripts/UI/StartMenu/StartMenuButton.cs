using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

///<summary> Class managing all the buttons in the StartMenu scene </summary>
public class StartMenuButton : MonoBehaviour
{
    private EndlessMenu em;

    [Header("Endless Menu Buttons")]
    ///<summary> Reference to the RightButton button in Endless Menu UI </summary>
    public Button rightArrow;
    ///<summary> Reference to the LeftButton button in Endless Menu UI </summary>
    public Button leftArrow;

    void Awake()
    {
        em = GetComponent<EndlessMenu>();    
    }

    void Update()
    {
        if(em.levelInfoIndex <= 0)
        {
            leftArrow.interactable = false;
        }
        else
        {
            leftArrow.interactable = true;
        }

        if(em.levelInfoIndex <= 0 || em.levelInfoIndex >= em.levels.Length - 1)
        {
            rightArrow.interactable = false;
        }
        else
        {
            rightArrow.interactable = true;
        }
    }

    #region Main_Select_Options

    ///<summary> [PLACEHOLDER] Loads a test level </summary>
    /// <param name="sceneName"> Name of the scene (MUST MATCH THE NAME IN BUILD) </param>
    public void OnCampaignClick(string sceneName)
    {
        if(sceneName == "")
        {
            Debug.LogError("Scene Name under StartMenu/UI/MainSelect/CampaignButton is not provided!");
            return;
        }

        SceneManager.LoadScene(sceneName);
    }

    /// <summary> [WIP] Activates the Endless Mode options. </summary>
    /// <param name="endlessMenu"> GameObject wielding the Endless Mode options UI </param>
    /// <param name="expandPanel"> GameObject wielding reference to the ExpandPanel UI </param>
    public void OnEndlessClick(GameObject endlessMenu)
    {
        if(endlessMenu == null)
        {
            Debug.LogError("endlessOptions GameObject under StartMenu/UI/MainSelect/EndlessButton not specified!");
            return;
        }

        endlessMenu.SetActive(true);
    }

    //-- USE IN CONJUNCTION WITH OnEndlessClick() or OnSettingsClick()
    public void ActivateExpandPanel(GameObject expandPanel)
    {
        if (expandPanel == null)
        {
            Debug.LogError("expandPanel GameObject under StartMenu/UI/MainSelect/EndlessButton not specified!");
            return;
        }

        expandPanel.SetActive(true);
    }

    ///<summary> [WIP] Activates the Settings menu </summary>
    ///<param name="settingsMenu"> GameObject wielding the Settings menu UI </param>
    public void OnSettingsClick(GameObject settingsMenu)
    {

    }

    /// <summary> Quits the game </summary>
    public void OnQuitClick()
    {
        Application.Quit();
    }

    #endregion

    #region Endless_Options

    public void OnPlayClick()
    {
        if(em.levelInfoIndex == 0)
        {
            SceneManager.LoadScene("TestLevel");
        }
    }

    public void OnRightClick()
    {
        em.levelInfoIndex++;
    }

    public void OnLeftClick()
    {
        em.levelInfoIndex--;
    }

    #endregion
}
