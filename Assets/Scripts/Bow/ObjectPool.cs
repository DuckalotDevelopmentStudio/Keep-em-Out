using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    /// <summary>
    /// CJ
    /// Pools any gameobject you want to spawn at a postion and rotation
    /// </summary>

    public int PoolCount;
    int currentIndex = 0;
    public GameObject PrefabToPool;
    public List<GameObject> ObjectList = new List<GameObject>();
    private TrailRenderer trailRenderer;

	void Start () {
        for (int i = 0; i < PoolCount; i++)
        {
            //Spawn the Objects far below the level
            GameObject go = GameObject.Instantiate(PrefabToPool, Vector3.down * 10000, Quaternion.identity);
            ObjectList.Add(go);
        }
	}

    /// <summary>
    /// CJ
    /// 
    /// Use this function to launch the arrow
    /// Example
    /// SpawnNextObject(Barrel.transform.position, Barrel.transform.rotation);
    /// </summary>
    public void SpawnNextObject(Vector3 pos, Quaternion rot)
    {
        ObjectList[currentIndex].transform.position = pos;
        ObjectList[currentIndex].transform.rotation = rot;
        ObjectList[currentIndex].GetComponentInChildren<TrailRenderer>().Clear();

        currentIndex++;
        if (currentIndex >= ObjectList.Count)
        {
            currentIndex = 0;
        }
    }	
}
