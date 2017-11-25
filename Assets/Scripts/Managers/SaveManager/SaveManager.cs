using UnityEngine;

namespace Project.Managers {
	public class SaveManager : MonoBehaviour {
		

		#region Singleton from SaveManager
		public static SaveManager m_Instance;
		#endregion

		void Awake () {
			#region Singleton from SaveManager
			if (m_Instance != null) {
				Debug.LogError("More then 1 instance found " + m_Instance.name);
				return;
			}
			m_Instance = this;
			#endregion
		}

		
		void Start () {
			
		}
		
	
		void Update () {
			
		}
	}
}