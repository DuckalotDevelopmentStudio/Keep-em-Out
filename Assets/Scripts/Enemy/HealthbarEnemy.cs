using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthbarEnemy : MonoBehaviour {


    public float CurrentHealth;
    public float MaxHealth;
    public Slider HealthBar;
    AIEnemy EnemyHealth;

	void Start () {
        EnemyHealth = GetComponent<AIEnemy>();
    }
	
	// Update is called once per frame
	void Update () {      
        HealthNiveau();
        HealthBar.value = CalculateHealth();
    }
    float CalculateHealth()
    {
        return CurrentHealth / MaxHealth;
    }
    void HealthNiveau()
    {
        CurrentHealth = EnemyHealth.CurrentHealth;
        MaxHealth = EnemyHealth.MaxHealth;
    }
}
