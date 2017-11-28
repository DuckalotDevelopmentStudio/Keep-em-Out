using UnityEngine;
using UnityEngine.UI;

namespace Fox.Flow {
	/// <summary>
	/// Orbit UI script with all the Button Components on it.
	/// </summary>
	public class OrbitUI : MonoBehaviour {

		[Header("To Fill")]
		/// <summary>
		/// The previous button to provide change fails.
		/// </summary>
		public Button m_PreviousButton;
		/// <summary>
		/// The next button to redo changes.
		/// </summary>
		public Button m_NextButton;

		/// <summary>
		/// The select button when he want select a Building block.
		/// </summary>
		public Button m_SelectButton;
		/// <summary>
		/// The delete button to delete Buildings.
		/// </summary>
		public Button m_DeleteButton;
		/// <summary>
		/// The reset camera Button to reset the camera.
		/// </summary>
		public Button m_ResetCameraButton;
		/// <summary>
		/// The rotate left button to rotate the Object.
		/// </summary>
		public Button m_RotateLeftButton;
		/// <summary>
		/// The rotate right button to rotate the Object.
		/// </summary>
		public Button m_RotateRightButton;

		/// <summary>
		/// The wall button to open the Build Inventory menu.
		/// </summary>
		public Button m_WallButton;
		/// <summary>
		/// The house button to open the Build inventory menu.
		/// </summary>
		public Button m_HouseButton;
		/// <summary>
		/// The weapons button to open the Build Inventory Menu.
		/// </summary>
		public Button m_WeaponsButton;
		/// <summary>
		/// The other button to open the Build Inventory Menu.
		/// </summary>
		public Button m_OtherButton;

		/// <summary>
		/// The instance and reference of the StateManager.
		/// </summary>
		public static OrbitUI m_Instance;

		/// <summary>
		/// The reference to this GameObject.
		/// </summary>
		[HideInInspector] public GameObject m_GOInstance;

		public HorizontalLayoutGroup m_BugfixTheFirstLayoutElement;


		#region Singlton
		void Awake() {
			if ( m_Instance != null ) {
				Debug.LogError( m_Instance.name + " already in the Scene: Please FIX!" );
				return;
			}
			m_Instance = this;
			m_GOInstance = this.gameObject;
		}
		#endregion

		void OnEnable() {
			m_BugfixTheFirstLayoutElement.padding.right = 10;
			m_BugfixTheFirstLayoutElement.padding.right = 20;
		}


		void Start () {
			ButtonFunction();
		}
	

		void Update () {
			
		}

		void ButtonFunction() {
			m_PreviousButton.onClick.AddListener( delegate() {
				onPreviousButtonClick();
			} );
			m_NextButton.onClick.AddListener( delegate() {
				onNextButtonClick();
			} );
			m_SelectButton.onClick.AddListener( delegate() {
				onSelectButtonClick();
			} );
			m_DeleteButton.onClick.AddListener( delegate() {
				onDeleteButtonClick();
			} );
			m_ResetCameraButton.onClick.AddListener( delegate() {
				onResetCameraButtonClick();
			} );
			m_RotateLeftButton.onClick.AddListener( delegate() {
				onRotateLeftButtonClick();
			} );
			m_RotateRightButton.onClick.AddListener( delegate() {
				onRotateRightButtonClick();
			} );
			m_WallButton.onClick.AddListener( delegate() {
				onWallButtonClick();
			} );
			m_HouseButton.onClick.AddListener( delegate() {
				onHouseButtonClick();
			} );
			m_WeaponsButton.onClick.AddListener( delegate() {
				onWeaponButtonClick();
			} );
			m_OtherButton.onClick.AddListener( delegate() {
				onOtherButtonClick();
			} );
		}

		public void onPreviousButtonClick() {
			//EventManager.RegisterEvent( this, "OnPrevious" );
		}

		void onNextButtonClick() {
			
		}

		void onSelectButtonClick() {
			
		}

		void onDeleteButtonClick() {
			
		}

		void onResetCameraButtonClick() {
			
		}

		void onRotateLeftButtonClick() {
			
		}

		void onRotateRightButtonClick() {
			
		}

		void onWallButtonClick() {
			
		}

		void onHouseButtonClick() {
			
		}

		void onWeaponButtonClick() {
			
		}

		void onOtherButtonClick() {
			
		}
	}
}
