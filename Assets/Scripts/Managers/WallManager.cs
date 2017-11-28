using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour {

    public List<GameObject> wallCapList = new List<GameObject>();

    private void Start()
    {
        GameObject[] wallCaps = FindObjectsOfType<GameObject>();

        //print(wallCaps.Length);

        foreach (GameObject g in wallCaps)
        {
            if (g.name == "WallCap")
            {
                wallCapList.Add(g);
                g.GetComponent<MeshRenderer>().enabled = false;
                g.GetComponent<MeshCollider>().enabled = false;
            }
        }
    }

    public List<GameObject> GetWallCaps()
    {
        return wallCapList;
    }
}
