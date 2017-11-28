using UnityEngine;
using UnityEngine.PostProcessing;

namespace Fox.Flow {
	/// <summary>
	/// Camera view mode to switch states
	/// </summary>
	public enum CameraViewMode {
		THIRD_PERSON,
		ORBIT
	}
	/// <summary>
	/// Player camera class to use the Camera
	/// </summary>
	public class PlayerCamera : MonoBehaviour {

		[Header("To Fill")]
		/// <summary>
		/// The orbit start position for the camera in a transform
		/// </summary>
		public Transform m_OrbitStartPosition;
		/// <summary>
		/// The first person camera position in a transform
		/// </summary>
		public Transform m_ThirdPersonCharacterAncher;
		/// <summary>
		/// The keys from the KeyManager Instance
		/// </summary>
		private KeyMamager m_Keys;
		/// <summary>
		/// The effects of the camera.
		/// </summary>
		private PostProcessingBehaviour m_Effects;
		/// <summary>
		/// The color settings to play with the contrast.
		/// </summary>
		private ColorGradingModel.Settings m_ColorSettings;
		/// <summary>
		/// The insance.
		/// </summary>
		 public static PlayerCamera m_Instance;

		/// <summary>
		/// The controller of the player.
		/// </summary>
		public PlayerController m_Controller;


		[Header("Monitoring")]
		/// <summary>
		/// The camera view mode.
		/// </summary>
		public CameraViewMode m_CameraViewMode = CameraViewMode.THIRD_PERSON;

		/// <summary>
		/// The switch modes bool false = cant switch
		/// </summary>
		private bool m_CanSwitchModes = true;

		/// <summary>
		/// The camera transform.
		/// </summary>
		private Transform m_CameraTransform;
		/// <summary>
		/// The camera rigidbody for collision dedection.
		/// </summary>
		private Rigidbody m_CameraRigidbody;

		[Header("Options")]
		/// <summary>
		/// The bool to make sure its get a switch to Orbit
		/// </summary>
		public bool m_NeedOrbit;
		/// <summary>
		/// The bool to make sure its get a switch to Third
		/// </summary>
		public bool m_NeedThird;

		/// <summary>
		/// The orbit speed multiplayer for the movement without SHIFT
		/// </summary>
		public float m_OrbitSpeedMultiplayer = 10f;
		/// <summary>
		/// The orbit SHIFT speed multiplayer (m_OrbitSpeedMultiplayer * m_OrbitSHIFTSpeedMultiplayer).
		/// </summary>
		public float m_OrbitSHIFTSpeedMultiplayer = 3f;
		private bool m_OrbitMultiplayerSave;
		/// <summary>
		/// The orbit rotation speed.
		/// </summary>
		public float m_OrbitRotationSpeed = 2f;

		/// <summary>
		/// The effect contrast save from the post-processing.
		/// </summary>
		private float m_EffectContrast;

		/// <summary>
		/// The third person camera offset.
		/// </summary>
		public Vector3 m_ThirdPersonCameraOffset = new Vector3(0f, 0f, -3f);

		/// <summary>
		/// The third person smooth out time while follow the target.
		/// </summary>
		[Range(0f,0.5f)] 
		public float m_ThirdPersonSmoothFollow = 0.3f;
		private Vector3 m_SmoothRef;

		/// <summary>
		/// The V minimum of the vertical mouse movement
		/// </summary>
		[Range(-90f, 0f)]
		public float m_VMin = -80f;
		/// <summary>
		/// The V minimum of the vertical mouse movement
		/// </summary>
		[Range(0f, 90f)]
		public float m_VMax = 80f;
		private float m_VerticalInput;
		private float m_SavedVertical;

		/// <summary>
		/// The third person mouse speed vertical.
		/// </summary>
		public float m_ThirdPersonMouseSpeedVertical = 0.9f;
		/// <summary>
		/// The third person mouse speed horiontal.
		/// </summary>
		public float m_ThirdPersonMouseSpeedHoriontal = 1f;

        Transform m_PlayerTransform;

        public bool inOrbitMode = false;

	#region Singlton
		void Awake() {
			if ( m_Instance != null ) {
				Debug.Log( "You have more then one Camera Component " + m_Instance.name + " dont do it, maybe you want create a coop mode then let me know that" );
				return;
			}
			m_Instance = this;
		}
	#endregion


		void Start () {
			m_Keys = KeyMamager.m_Instance;
			m_CameraTransform = this.transform;

            //CJ
            m_PlayerTransform = FindObjectOfType<PlayerController>().transform;

			m_Effects = this.GetComponent<PostProcessingBehaviour>();
			m_EffectContrast = m_Effects.profile.colorGrading.settings.basic.contrast;

			m_CameraRigidbody = this.GetComponent<Rigidbody>();

			m_Controller = PlayerController.m_Instance;

			switch (m_CameraViewMode) {
			case CameraViewMode.ORBIT:
				{
					m_NeedOrbit = true;
					break;
				}
			case CameraViewMode.THIRD_PERSON:
				{
					m_NeedThird = true;
					break;
				}
			}
		}
	

		void Update () {
			checkInput();
			graphicalModeSwitch();

		}

		void FixedUpdate() {
			if ( m_CameraViewMode == CameraViewMode.ORBIT ) {
				if ( Input.GetAxis( m_Keys.m_HoirzontalAxis.m_UnityInputName ) != 0f || Input.GetAxis( m_Keys.m_VerticalAxis.m_UnityInputName ) != 0f ) {
					Vector2 movement = new Vector2( Input.GetAxis( m_Keys.m_HoirzontalAxis.m_UnityInputName ),
					                           Input.GetAxis( m_Keys.m_VerticalAxis.m_UnityInputName ));
					OrbitMovement( movement );
				}
			}
			if ( m_CameraViewMode == CameraViewMode.THIRD_PERSON ) {
				ThirdPersonFollow( m_VerticalInput );
			}
		}

		/// <summary>
		/// Sets the camera to first person.
		/// </summary>
		public void SetCameraToThirdPerson() {
			if ( m_CanSwitchModes ) {
				m_CameraTransform.position = m_ThirdPersonCharacterAncher.position;
				m_CameraTransform.rotation = m_ThirdPersonCharacterAncher.rotation;
				m_CameraViewMode = CameraViewMode.THIRD_PERSON;
				Cursor.lockState = CursorLockMode.None;
				Cursor.lockState = CursorLockMode.Locked;
				StateManager.m_Instance.ThirdPersonModeStart();

                AIEnemy[] enemies = FindObjectsOfType<AIEnemy>();
                for (int i = 0; i < enemies.Length; i++)
                {
                    enemies[i].PauseAI = false;
                }
            }
		}

		/// <summary>
		/// Sets the camera to orbit.
		/// </summary>
		public void SetCameraToOrbit() {
			if ( m_CanSwitchModes ) {

                //CJ EDIT
				m_CameraTransform.position = m_PlayerTransform.position + m_PlayerTransform.up * 2 + -m_PlayerTransform.forward * 2;
				m_CameraTransform.rotation = m_PlayerTransform.rotation;

                AIEnemy[] enemies = FindObjectsOfType<AIEnemy>();
                for (int i = 0; i < enemies.Length; i++)
                {
                    enemies[i].PauseAI = true;
                }

				m_CameraViewMode = CameraViewMode.ORBIT;
				Cursor.lockState = CursorLockMode.None;
				Cursor.lockState = CursorLockMode.Confined;
				StateManager.m_Instance.OrbitModeStart();
			}
		}

		/// <summary>
		/// Checks the input.
		/// </summary>
		void checkInput() {
			// Testing START
			if ( Input.GetKeyDown( m_Keys.m_SwitchCameraModeKeyTESTING.m_Keycode ) && m_CameraViewMode == CameraViewMode.ORBIT && !m_NeedOrbit ) {
				m_NeedThird = true;
                inOrbitMode = false;
				return;
			}
			if ( Input.GetKeyDown( m_Keys.m_SwitchCameraModeKeyTESTING.m_Keycode ) && m_CameraViewMode == CameraViewMode.THIRD_PERSON && !m_NeedThird ) {
				m_NeedOrbit = true;
                inOrbitMode = true;
				return;
			}
			// Testing END

			if ( m_CameraViewMode == CameraViewMode.ORBIT ) {
				if ( Input.GetKey( m_Keys.m_LeftShift.m_Keycode ) ) {
					if ( !m_OrbitMultiplayerSave ) {
						m_OrbitSpeedMultiplayer = m_OrbitSpeedMultiplayer * m_OrbitSHIFTSpeedMultiplayer;
						m_OrbitMultiplayerSave = true;
					}
				} else {
					if ( m_OrbitMultiplayerSave ) {
						m_OrbitSpeedMultiplayer = m_OrbitSpeedMultiplayer / m_OrbitSHIFTSpeedMultiplayer;
						m_OrbitMultiplayerSave = false;
					}
				}
				if ( Input.GetKey( m_Keys.m_MouseRight.m_Keycode ) ) {
					Vector2 movment = new Vector2( Input.GetAxis( m_Keys.m_MouseX.m_UnityInputName ),
					                              Input.GetAxis( m_Keys.m_MouseY.m_UnityInputName ));
					OrbitRotation( movment );
				}
			}
			if ( m_CameraViewMode == CameraViewMode.THIRD_PERSON ) {
				m_VerticalInput = Input.GetAxis( m_Keys.m_MouseY.m_UnityInputName );
			}
		}

		/// <summary>
		/// Visualice the mode switch.
		/// </summary>
		void graphicalModeSwitch() {
			if ( m_NeedOrbit ) {
				if ( m_CameraViewMode == CameraViewMode.THIRD_PERSON ) {
					m_ColorSettings = m_Effects.profile.colorGrading.settings;
					m_ColorSettings.basic.contrast -= Time.deltaTime;
					m_Effects.profile.colorGrading.settings = m_ColorSettings;
				}

				if ( m_ColorSettings.basic.contrast < 0.01f ) {
					SetCameraToOrbit();
				}

				if ( m_CameraViewMode == CameraViewMode.ORBIT ) {
					m_ColorSettings = m_Effects.profile.colorGrading.settings;
					m_ColorSettings.basic.contrast += Time.deltaTime;
					m_Effects.profile.colorGrading.settings = m_ColorSettings;
				}

				if ( m_ColorSettings.basic.contrast >= m_EffectContrast ) {
					m_ColorSettings.basic.contrast = m_EffectContrast;
					m_Effects.profile.colorGrading.settings = m_ColorSettings;
					m_NeedOrbit = false;
				}
			}
			if ( m_NeedThird ) {
				if ( m_CameraViewMode == CameraViewMode.ORBIT ) {
					m_ColorSettings = m_Effects.profile.colorGrading.settings;
					m_ColorSettings.basic.contrast -= Time.deltaTime;
					m_Effects.profile.colorGrading.settings = m_ColorSettings;
				}

				if ( m_ColorSettings.basic.contrast < 0.01f ) {
					SetCameraToThirdPerson();
				}

				if ( m_CameraViewMode == CameraViewMode.THIRD_PERSON ) {
					m_ColorSettings = m_Effects.profile.colorGrading.settings;
					m_ColorSettings.basic.contrast += Time.deltaTime;
					m_Effects.profile.colorGrading.settings = m_ColorSettings;
				}

				if ( m_ColorSettings.basic.contrast >= m_EffectContrast ) {
					m_ColorSettings.basic.contrast = m_EffectContrast;
					m_Effects.profile.colorGrading.settings = m_ColorSettings;
					m_NeedThird = false;
				}
			}
		}

		/// <summary>
		/// the movement for Orbit.
		/// </summary>
		/// <param name="input">Input for the WASD</param>
		void OrbitMovement(Vector2 input) {
			m_CameraRigidbody.velocity = m_CameraTransform.TransformDirection( input.x, 0f, input.y ) * Time.fixedDeltaTime * m_OrbitSpeedMultiplayer;
		}

		/// <summary>
		/// the rotation for orbit.
		/// </summary>
		/// <param name="input">Input from the mouse</param>
		void OrbitRotation(Vector2 input) {
			Vector3 rot = m_CameraTransform.rotation.eulerAngles;
			m_CameraTransform.rotation = Quaternion.Euler( m_CameraTransform.TransformDirection( new Vector3( -input.y,
			                                                                                                  input.x,
			                                                                                                  0f ) * m_OrbitRotationSpeed ) ) * Quaternion.Euler( rot.x,
			                                                                                                                                                     rot.y,
			                                                                                                                                                     0f );
		}

		/// <summary>
		/// the Third person camera follow.
		/// </summary>
		/// <param name="verticalMouse">Vertical mouse input.</param>
		void ThirdPersonFollow(float verticalMouse) {
			Vector3 offsetPosition = m_ThirdPersonCharacterAncher.position + m_ThirdPersonCharacterAncher.TransformDirection( m_ThirdPersonCameraOffset );
			Vector3 offsetRotation = m_ThirdPersonCharacterAncher.rotation.eulerAngles;


			m_SmoothRef = m_SmoothRef * Time.smoothDeltaTime;
			m_CameraTransform.position = Vector3.SmoothDamp( m_CameraTransform.position,
			                                                offsetPosition,
			                                                ref m_SmoothRef,
			                                                m_ThirdPersonSmoothFollow);

			m_SavedVertical = m_SavedVertical + (verticalMouse * m_ThirdPersonMouseSpeedVertical);
			m_SavedVertical = Mathf.Clamp( m_SavedVertical, m_VMin, m_VMax );

			m_ThirdPersonCharacterAncher.rotation = Quaternion.Euler( m_Controller.m_ControllerTransform.TransformDirection( new Vector3( -m_SavedVertical,
			                                                                                                                             0f,
			                                                                                                                             0f ) ) ) * m_Controller.m_ControllerTransform.rotation;
			m_CameraTransform.rotation = Quaternion.Euler( offsetRotation );
		}
	}
}
