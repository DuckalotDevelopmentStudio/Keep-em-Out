using UnityEngine;

namespace Project.Managers.Properties {
	[System.Serializable]
	/// <summary>
	/// Key serialized to store the Key Data
	/// </summary>
	public class KeySerialized  {

		/// <summary>
		/// The name of the unity input.
		/// </summary>
		public string m_UnityInputName = "NoInput";
		/// <summary>
		/// The keycode you want to pick
		/// </summary>
		public KeyCode m_Keycode;

		/// <summary>
		/// The name of the key data class
		/// </summary>
		public string m_KeyName;

		[HideInInspector] public string m_SavedInputName;
		[HideInInspector] public KeyCode m_SavedKey;


	}
}
