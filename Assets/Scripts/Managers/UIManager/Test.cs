using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Managers; //-- ALLOWS THE USAGE OF UIManager AND EVERY OTHER MANAGER SCRIPT

public class Test : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            //-- GET THE instance SINGLETON VARIABLE INSIDE OF UIManager, THEN CHOOSE YOUR DESIRED METHOD
            UIManager.instance.EnableUIObjects(new string[] {"HP", "Ammo", "Crosshair"});
        }
    }
}
