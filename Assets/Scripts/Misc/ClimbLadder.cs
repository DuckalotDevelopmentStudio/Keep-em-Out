using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fox.Flow;

public class ClimbLadder : MonoBehaviour
{
    public float m_ClimbSpeed = 4;
    GameObject m_Player;
    Rigidbody m_RigidBody;
    Collider m_LadderCollider;
    PlayerController playerController;

    bool jumpFromLadder = false;

    private void Start()
    {
        m_LadderCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        playerController = other.GetComponent<PlayerController>();
        m_Player = other.gameObject;
        m_RigidBody = other.GetComponent<Rigidbody>();
    }

    /// <CJ>
    /// When the player enters the trigger they can press W or S to go up or down
    /// They automatically get locked into the ladder until they either press jump or move to the top
    /// of the ladder or touch the bottom.
    /// </>
    private void OnTriggerStay(Collider other)
    {

        if (playerController != null)
        {
                       
            m_RigidBody.useGravity = false;

            float verticalAxis = Input.GetAxis(KeyMamager.m_Instance.m_VerticalAxis.m_UnityInputName);

            Vector3 localVelocity = transform.InverseTransformDirection(m_RigidBody.velocity);
            localVelocity.y = verticalAxis * m_ClimbSpeed;

            Vector3 worldVelocity = transform.TransformDirection(localVelocity);
            m_RigidBody.velocity = worldVelocity;

            bool jump = Input.GetKeyDown(KeyMamager.m_Instance.m_Jump.m_Keycode);

            if (playerController.m_IsGrounded)
            {
                return;
            }

            if (!jump)
            {
                m_Player.transform.position = new Vector3(transform.position.x, m_Player.transform.position.y, transform.position.z);
            }
            else
            {
                jumpFromLadder = true;
                m_RigidBody.useGravity = true;
                m_LadderCollider.enabled = false;
                StartCoroutine("EnableCollider");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();

        if (playerController != null)
        {
            m_Player = other.gameObject;
            m_RigidBody = other.GetComponent<Rigidbody>();
            m_RigidBody.useGravity = true;
        }
    }

    IEnumerator EnableCollider()
    {
        if (jumpFromLadder)
        {
            yield return new WaitForSeconds(1);
            m_LadderCollider.enabled = true;
            jumpFromLadder = false;
        }
    }
}
