using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowMechanism : MonoBehaviour {
    
    private Animator anim;
    public float damage;
    public float power;
    private bool Click;
    private bool Release;
    public GameObject Arrow;
    public GameObject DisplayArrow;
    private GameObject Barrel;
    
	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator>();
		Barrel = GameObject.FindWithTag ("Barrel");
	}
	
	// Update is called once per frame
	void Update () {
	    anim.SetBool("Released", Release);
	    anim.SetBool("Clicked", Click);
	    Release = false;
	    if (power >= 3){
	        power = 3;
	    }
		if (Input.GetButton("Fire1")){
		    Click = true;
		    power += Time.deltaTime;
		    DisplayArrow.SetActive(true);
		}
		else if (Input.GetButtonUp("Fire1") && power > 0){
		  Click = false;
		  Release = true;
		  damage = power * 3;
		  
		  Instantiate(Arrow, Barrel.transform.position, Barrel.transform.rotation, Barrel.transform);
		  DisplayArrow.SetActive(false);
		}
		}
	}

