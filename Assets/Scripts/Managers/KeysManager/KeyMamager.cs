using UnityEngine;
using System.Collections.Generic;
using Project.Managers.Properties;

namespace Project.Managers {
	/// <summary>
	/// Key mamager for the UI and to disable all Keys
	/// </summary>
	public class KeyMamager : MonoBehaviour {

		/// <summary>
		/// The instance of the Script
		/// </summary>
		public static KeyMamager m_Instance;

		/// <summary>
		/// The keys stored in a List
		/// </summary>
		private List<KeySerialized> m_Keys = new List<KeySerialized>();

		/// <summary>
		/// The name of the unused Button to get a key who have no value
		/// </summary>
		public string m_NoInputName = "NoInput";

		/// <summary>
		/// Check if all Keys are disabled
		/// </summary>
		private bool m_IsDisabled = false;


		// TODO: When you need a Key who is NOT in the Keys below you need to hardcode it down like i did and add them to the list in the Start function
		public KeySerialized m_SwitchCameraModeKeyTESTING;
		public KeySerialized m_FocusInOrbitMode;
		public KeySerialized m_HoirzontalAxis;
		public KeySerialized m_VerticalAxis;
		public KeySerialized m_LeftShift;
		public KeySerialized m_MouseX;
		public KeySerialized m_MouseY;
		public KeySerialized m_MouseRight;
		public KeySerialized m_MouseLeft;
		public KeySerialized m_Jump;
		public KeySerialized m_Fire;

        #region Singleton
        void Awake() {
			if ( m_Instance != null ) {
				Debug.LogError( "More then ONE KeyManager in the Scene " + m_Instance.name + " please FIX" );
				return;
			}
			m_Instance = this;
		}
		#endregion


		void Start() {
			// TODO: Add your keys there
			m_Keys.Add(m_SwitchCameraModeKeyTESTING);
			m_Keys.Add(m_FocusInOrbitMode);
			m_Keys.Add(m_HoirzontalAxis);
			m_Keys.Add(m_VerticalAxis);
			m_Keys.Add( m_LeftShift );
			m_Keys.Add( m_MouseX );
			m_Keys.Add( m_MouseY );
			m_Keys.Add( m_MouseRight );
			m_Keys.Add( m_MouseLeft );
			m_Keys.Add( m_Jump );
			m_Keys.Add( m_Fire );
            // There

            for ( int i = 0; i < m_Keys.Count; i++ ) {
				m_Keys[ i ].m_SavedKey = m_Keys[ i ].m_Keycode;
				m_Keys[ i ].m_SavedInputName = m_Keys[ i ].m_UnityInputName;
			}
		}


		/// <summary>
		/// Disables all keys
		/// </summary>
		public void DisableAllKeys() {
			for ( int i = 0; i < m_Keys.Count; i++ ) {
				m_Keys[ i ].m_SavedKey = m_Keys[ i ].m_Keycode;
				m_Keys[ i ].m_SavedInputName = m_Keys[ i ].m_UnityInputName;
				m_Keys[ i ].m_Keycode = KeyCode.None;
				m_Keys[ i ].m_UnityInputName = m_NoInputName;
			}
			m_IsDisabled = true;
		}

		/// <summary>
		/// Enables all keys
		/// </summary>
		public void EnableAllKeys() {
			if ( m_IsDisabled ) {
				for ( int i = 0; i < m_Keys.Count; i++ ) {
					m_Keys[ i ].m_Keycode = m_Keys[ i ].m_SavedKey;
					m_Keys[ i ].m_UnityInputName = m_Keys[ i ].m_SavedInputName;
				}
			} else {
				Debug.Log( "You need to Disable all kays first" );
			}
		}

		/// <summary>
		/// Disables one key.
		/// </summary>
		/// <param name="keyName">Key name from the Key Data</param>
		public void DisableOneKey(string keyName) {
			for ( int i = 0; i < m_Keys.Count; i++ ) {
				if ( keyName == m_Keys[ i ].m_KeyName ) {
					m_Keys[ i ].m_SavedKey = m_Keys[ i ].m_Keycode;
					m_Keys[ i ].m_SavedInputName = m_Keys[ i ].m_UnityInputName;
					m_Keys[ i ].m_Keycode = KeyCode.None;
					m_Keys[ i ].m_UnityInputName = m_NoInputName;
				}
			}
		}

		/// <summary>
		/// Enables one key.
		/// </summary>
		/// <param name="keyName">Key name from the Key Data</param>
		public void EnableOneKey(string keyName) {
			for ( int i = 0; i < m_Keys.Count; i++ ) {
				if ( keyName == m_Keys[ i ].m_KeyName ) {
					m_Keys[ i ].m_Keycode = m_Keys[ i ].m_SavedKey;
					m_Keys[ i ].m_UnityInputName = m_Keys[ i ].m_SavedInputName;
				}
			}
		}
	}
}
