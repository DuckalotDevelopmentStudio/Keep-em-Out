using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fox.Flow;

// Ironmanhood
public class BowAnimations : MonoBehaviour
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
        if (Input.GetKey(m_Keys.m_Fire.m_Keycode))
        {
            if (Input.GetKeyDown(m_Keys.m_Fire.m_Keycode))
            {
                _anim.SetBool("isHoldingFireButton", true);
            }
                
            // If we are currently drawing the bow back.
            if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Draw"))
            {
                // If the draw animation has finished, then set isDrawn to true.
                if (_anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                {
                    // Avoid setting the variable every frame.
                    if (!_anim.GetBool("isDrawn"))
                        _anim.SetBool("isDrawn", true);
                }
            }
        }
        else if(Input.GetKeyUp(m_Keys.m_Fire.m_Keycode))
        {
            // Reset isHoldingFireButton to false when we release the fire button.
            _anim.SetBool("isHoldingFireButton", false);
        }

        // Set isDrawn to false when we enter the Idle animation state.
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            if (_anim.GetBool("isDrawn"))
                _anim.SetBool("isDrawn", false);
        }
    }
}

