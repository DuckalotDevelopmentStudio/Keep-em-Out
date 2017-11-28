
using UnityEngine;

public class BowShoot : MonoBehaviour {

    public float timeIsHolding = 0f;
    private bool wasHolding = false;
    
    public Rigidbody arrowPrefab;
    public Transform arrowSpawnPoint;

	// Use this for initialization
	void Start () {
        Instantiate(arrowPrefab, arrowSpawnPoint);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(1))
        {
            timeIsHolding += Time.deltaTime;
        }
        else
        {
            Shoot(timeIsHolding);
        }
	}
    void Shoot(float bowPower)
    {
        Mathf.Clamp(bowPower, 0, 2);
        //bowPower *= 10f;
        //arrowPrefab.AddForce(transform.forward * bowPower);
    }
}
