using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMechanism : MonoBehaviour {
    private BowMechanism BowReference;
    private float Damage;
    private GameObject Bow;


	// Update is called once per frame
	void Start () {
	    Bow = GameObject.FindWithTag ("Bow");
	    BowReference = Bow.GetComponent <BowMechanism>();
		Rigidbody rb = GetComponent <Rigidbody>();
	    Damage = BowReference.damage;
		rb.velocity = transform.up * BowReference.power;
	}
}
