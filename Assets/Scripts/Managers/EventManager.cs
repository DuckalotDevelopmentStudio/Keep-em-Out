using UnityEngine;
using System.Collections.Generic;
using System;

namespace Fox.Flow {
	public class EventManager : MonoBehaviour {

		/// <summary>
		/// The active events.
		/// </summary>
		public List<EventSerialized> m_ActiveEvents;
		/// <summary>
		/// The instance.
		/// </summary>
		public static EventManager m_Instance;

#region Siglton
		void Awake() {
			if ( m_Instance != null ) {
				Debug.LogError( "More then one " + m_Instance.name + " Manager in the scene!" );
				return;
			}
			m_Instance = this;
			m_ActiveEvents.Clear();
		}
#endregion


		/// <summary>
		/// Registers the event.
		/// </summary>
		/// <param name="Caller">the script who is the Caller.</param>
		/// <param name="EventName">The Event name.</param>
		public static void RegisterEvent(Behaviour Caller, string EventName) {
			EventSerialized Event = new EventSerialized();
			Event.m_Caller = Caller;
			Event.m_Name = EventName;
			EventManager.m_Instance.m_ActiveEvents.Add( Event );
		}

		/// <summary>
		/// Unregisters the event.
		/// </summary>
		/// <param name="EventName">The Event name.</param>
		public static void UnregisterEvent(string EventName) {
			EventManager manager = EventManager.m_Instance;
			for ( int i = 0; i < manager.m_ActiveEvents.Count; i++ ) {
				if (EventName == manager.m_ActiveEvents[i].m_Name) {
					manager.m_ActiveEvents.Remove( manager.m_ActiveEvents[ i ] );
					return;
				}
			}
		}
	}
}
