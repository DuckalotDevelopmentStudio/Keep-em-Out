using System;
using UnityEngine;

namespace Fox.Flow {
	[RequireComponent(typeof(Rigidbody))]
	/// <summary>
	/// Player controller to handle all the movment
	/// </summary>
	public class PlayerController : MonoBehaviour {

		/// <summary>
		/// The keys instance
		/// </summary>
		private KeyMamager m_Keys;
		/// <summary>
		/// The camera instance
		/// </summary>
		private PlayerCamera m_Camera;
		/// <summary>
		/// The rigidbody of the controller
		/// </summary>
		private Rigidbody m_Rigidbody;
		/// <summary>
		/// The controller transform.
		/// </summary>
		[HideInInspector] public Transform m_ControllerTransform;
		/// <summary>
		/// The capsule collider of the controller.
		/// </summary>
		private CapsuleCollider m_CapsuleCollider;
		/// <summary>
		/// The movement input.
		/// </summary>
		private Vector2 m_MovementInput;

        


		[Header("Options")]
		/// <summary>
		/// The ground speed.
		/// </summary>
		public float m_GroundSpeed = 10f;

		/// <summary>
		/// The ground material.
		/// </summary>
		public PhysicMaterial m_GroundMaterial;

		/// <summary>
		/// The air speed.
		/// </summary>
		public float m_AirSpeed = 5f;

		/// <summary>
		/// The air material.
		/// </summary>
		public PhysicMaterial m_AirMaterial;

		/// <summary>
		/// The grounded bool.
		/// </summary>
		public bool m_IsGrounded = false;

		/// <summary>
		/// The idle bool.
		/// </summary>
		public bool m_IsIdle = false;
		private bool m_IdleSave;

		public PhysicMaterial m_IdleMaterial;

		/// <summary>
		/// The ground offset for the grounded effect.
		/// </summary>
		public float m_GroundOffset = 0.1f;

		/// <summary>
		/// The ground layer who gets effected by the grounded bool.
		/// </summary>
		public LayerMask m_GroundLayer;

		/// <summary>
		/// The jump speed.
		/// </summary>
		public float m_JumpSpeed = 10f;

		/// <summary>
		/// The instance to reference the script.
		/// </summary>
		public static PlayerController m_Instance;

        public GameObject BowBarrel;

        #region Singlton
        void Awake() {
			if ( m_Instance != null ) {
				Debug.Log( "You have more then one Controller Component " + m_Instance.name + " dont do it, maybe you want create a coop mode then let me know that" );
				return;
			}
			m_Instance = this;
		}
	#endregion

		void Start () {
			m_Camera = PlayerCamera.m_Instance;
			m_Keys = KeyMamager.m_Instance;
			m_Rigidbody = this.GetComponent<Rigidbody>();
			m_CapsuleCollider = this.GetComponent<CapsuleCollider>();
			m_ControllerTransform = this.transform;
		}
	

		void Update() {
			if ( m_Camera.m_CameraViewMode == CameraViewMode.THIRD_PERSON ) {
				getMovementInput();
				Rotate( Input.GetAxis( m_Keys.m_MouseX.m_UnityInputName ) );
			}
		}


		void FixedUpdate () {
			if ( m_Camera.m_CameraViewMode == CameraViewMode.THIRD_PERSON ) {
				Move( m_MovementInput );
				CheckGround();
				Jump();
                FireBow();

			}
		}

        private void FireBow()
        {
            BowBarrel.transform.rotation = Quaternion.Euler(m_Camera.transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

            if (Input.GetButtonUp("Fire1"))
            {
                GetComponentInChildren<ObjectPool>().SpawnNextObject(BowBarrel.transform.position, BowBarrel.transform.rotation);
            }
        }

        /// <summary>
        /// Gets the movement input.
        /// </summary>
        void getMovementInput() {
			m_MovementInput = new Vector2( Input.GetAxis( m_Keys.m_HoirzontalAxis.m_UnityInputName ),
			                              Input.GetAxis( m_Keys.m_VerticalAxis.m_UnityInputName ));
			if ( m_MovementInput == Vector2.zero && m_IsGrounded ) {
				m_IsIdle = true;
			} else {
				m_IsIdle = false;
			}
		}

		/// <summary>
		/// Move with the specified input.
		/// </summary>
		/// <param name="input">Input (WASD)</param>
		void Move(Vector2 input) {
			Vector3 vel = m_Rigidbody.velocity;
			if ( m_IsGrounded ) {
				vel = m_ControllerTransform.TransformDirection( new Vector3( input.x * m_GroundSpeed,
				                                                             vel.y,
				                                                             input.y * m_GroundSpeed ) );
			} else {
				vel = m_ControllerTransform.TransformDirection( new Vector3( input.x * m_AirSpeed,
				                                                             vel.y,
				                                                             input.y * m_AirSpeed ) );
			}
				

			m_Rigidbody.velocity = vel;
		}

		/// <summary>
		/// Checks the ground with a SphareCast.
		/// </summary>
		void CheckGround() {
			RaycastHit hit;
			if ( Physics.SphereCast( m_CapsuleCollider.center + m_ControllerTransform.position,
			                         m_CapsuleCollider.radius * 0.9f,
			                         Vector3.down,
			                         out hit,
			                         ( m_CapsuleCollider.height / 2f ) + m_GroundOffset,
			                         m_GroundLayer ) ) {
				if ( m_IsGrounded && !m_IsIdle ) {
					m_CapsuleCollider.material = m_GroundMaterial;
					m_IdleSave = false;
				} else if ( m_IsIdle && !m_IdleSave && m_IsGrounded ) {
						m_CapsuleCollider.material = m_IdleMaterial;
						m_IdleSave = false;
				}
				if ( !m_IsGrounded ) {
					m_IsGrounded = true;
				}
			} else {
				if ( m_IsGrounded ) {
					m_CapsuleCollider.material = m_AirMaterial;
				}
				if ( m_IsGrounded ) {
					m_IsGrounded = false;
				}
			}
		}

		/// <summary>
		/// Jump function.
		/// </summary>
		void Jump() {
			if ( Input.GetKeyDown( m_Keys.m_Jump.m_Keycode ) && m_IsGrounded ) {
				Vector3 vel = m_Rigidbody.velocity;

				vel = new Vector3( vel.x, m_JumpSpeed, vel.z );

				m_Rigidbody.velocity = vel;
			}
		}

		/// <summary>
		/// Rotate the specified horizontal Input.
		/// </summary>
		/// <param name="horizontalInput">Horizontal input.</param>
		void Rotate(float horizontalInput) {
			m_ControllerTransform.rotation = Quaternion.Euler( new Vector3( 0f,
			                                                                horizontalInput * m_Camera.m_ThirdPersonMouseSpeedHoriontal,
			                                                                0f ) ) * m_ControllerTransform.rotation;
		}
	}
}
