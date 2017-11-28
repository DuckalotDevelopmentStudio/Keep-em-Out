using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject expandPanel;

    public GameObject endlessMenu;

    void Awake()
    {
        expandPanel.SetActive(false);
        endlessMenu.SetActive(false);
    }
}
