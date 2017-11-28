using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fox.Flow;

// Ironmanhood
public class playerAnimations : MonoBehaviour
{


    private KeyMamager m_Keys;
    Animator _anim;

    // Use this for initialization
    void Start ()
    {
        m_Keys = KeyMamager.m_Instance;
        _anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        _anim.SetFloat("Horizontal_Input", Input.GetAxis("Horizontal"));
        _anim.SetFloat("Vertical_Input", Input.GetAxis("Vertical"));
    }
}
