using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHealth : MonoBehaviour {

    public float TotalHealth = 100f;
    public float CurrentHealth;
    public float Damage = 5f;
    public float MaxAdjacentDistance = 16;

    public List<GameObject> adjacentWallCapList = new List<GameObject>();

    bool Death = false;

    public bool isObstructed;

    void Start () {
        CurrentHealth = TotalHealth;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<WallHealth>())
        {
            //print("IsObstructed");
            isObstructed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<WallHealth>())
        {
            //print("NotObstructed");
            isObstructed = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<WallHealth>())
        {
           //print("IsObstructed");
            isObstructed = true;
        }
    }

    void Update () {
        
        if (CurrentHealth <= 0 && !Death)
        {
            GameOver();
        }
	}


    /// <summary>
    /// CJ
    /// 
    /// When this wall is killed by the enemy
    /// Find the adjacent 2 walls and enable the WallCap
    /// </summary>
    private void OnDisable()
    {
        //If it doesnt have WallCaps do nothing.
        if (transform.childCount == 0)
        {
            return;
        }

        CapAdjacentWalls();
    }


    /// <summary>
    /// CJ
    /// The WallManager gets every gameobject if the gameobjects name is WallCap
    /// it puts it into wallCapList. It then removes the WallCaps on this object to
    /// stop distance confliction with adjacent walls. Then it sorts by distance the 2 closest walls if there are 2
    /// re-enables the wallcaps and the AI moves onto the next target
    /// </summary>
    public void CapAdjacentWalls()
    {
        List<GameObject> wallCapList = new List<GameObject>();
        if (!FindObjectOfType<WallManager>())
        {
            return;
        }

        wallCapList = FindObjectOfType<WallManager>().GetWallCaps();

        
        wallCapList.Remove(transform.GetChild(0).gameObject);
        wallCapList.Remove(transform.GetChild(1).gameObject);

        if (wallCapList.Count < 3)
        {
            return;
        }

        //Put the closest wallcap at index 0
        wallCapList.Sort(delegate (GameObject x, GameObject y)
        {
            return Vector3.Distance(x.transform.position, transform.position).CompareTo(Vector3.Distance(y.transform.position, transform.position));
        });

        GameObject lastWallCapped = null;

        for (int i = 0; i < 2; i++)
        {
            if (lastWallCapped == wallCapList[i].transform.parent.gameObject)
            {
                return;
            }

            if (Vector3.Distance(transform.position, wallCapList[i].transform.position) > MaxAdjacentDistance)
            {
                return;
            }

            wallCapList[i].GetComponent<MeshRenderer>().enabled = true;
            wallCapList[i].GetComponent<MeshCollider>().enabled = true;
            adjacentWallCapList.Add(wallCapList[i]);
            lastWallCapped = wallCapList[i].transform.parent.gameObject;

        }
    }

    //This function can be used for starting a game over animation
    public void GameOver()
    {
        Death = true;
        Debug.Log("GameOver");
        
    }
}
