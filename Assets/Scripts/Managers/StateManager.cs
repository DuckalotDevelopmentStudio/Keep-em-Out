using UnityEngine;

namespace Fox.Flow {
	public class StateManager : MonoBehaviour {

		/// <summary>
		/// The instance and reference of the StateManager.
		/// </summary>
		public static StateManager m_Instance;


		private OrbitUI m_OrbitUI;
		private PlayerCamera m_PlayerCamera;
        


#region Singlton
		void Awake() {
			if ( m_Instance != null ) {
				Debug.LogError( m_Instance.name + " already in the Scene: Please FIX!" );
				return;
			}
			m_Instance = this;
		}
#endregion

		void Start() {
			m_OrbitUI = OrbitUI.m_Instance;
			m_PlayerCamera = PlayerCamera.m_Instance;
		}

		public void OrbitModeStart() {
			m_OrbitUI.m_GOInstance.SetActive( true );
		}

		public void ThirdPersonModeStart() {
			m_OrbitUI.m_GOInstance.SetActive( false );
		}

	}
}
