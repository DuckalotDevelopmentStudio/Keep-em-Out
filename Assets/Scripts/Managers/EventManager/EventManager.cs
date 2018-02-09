using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using System;

namespace Project.Managers {
	/// <summary>
	/// Event manager. He handles all events in the game
	/// </summary>
	public class EventManager : MonoBehaviour {

		/// <summary>
		/// The events.
		/// </summary>
		public List<DuckalotEvent> Events = new List<DuckalotEvent> ();

		public float EventCleanupTimer = 10f;
		private float EventCleanupTimerSave;

		#region Singleton from EventManager
		public static EventManager m_Instance;
		#endregion

		void Awake () {
			if (Events == null)
			{
				Events = new List<DuckalotEvent>();
			}

			#region Singleton from EventManager
			if (m_Instance != null) {
				Debug.LogError("More then 1 instance found " + m_Instance.name);
			//	m_Instance = this;
				return;
			}
			m_Instance = this;
			#endregion
			EventCleanupTimerSave = EventCleanupTimer;
			//Events = new List<DuckalotEvent>();
		}

		void Update() {
			EventCleanupTimerSave -= Time.deltaTime;
			if ( EventCleanupTimerSave < 0f ) {
				CleanUpEvents ();
				EventCleanupTimerSave = EventCleanupTimer;
			}
		}

		public static void CleanUpEvents() {
			for ( int i = 0; i < m_Instance.Events.Count; i++ ) {
				if ( m_Instance.Events[i].caller == null ) {
					m_Instance.Events [i].RemoveAllListerners ();
					m_Instance.Events.Remove ( m_Instance.Events [i] );
				} else {
					for (int y = 0; y < m_Instance.Events[i].listerners.Count; y++) {
						if ( m_Instance.Events[i].listerners[y].caller == null ) {
							m_Instance.Events [i].RemoveListerner ( m_Instance.Events [i].listerners [y].name );
						}
					}
				}
			}
		}

		/// <summary>
		/// Registers the event.
		/// </summary>
		/// <returns>The event.</returns>
		/// <param name="EventName">Event name.</param>
		/// <param name="script">Script from where you call the event</param>
		public static DuckalotEvent RegisterEvent( string EventName, Behaviour script ) {

			DuckalotEvent e = new DuckalotEvent();

			e.name = EventName;
			e.isRegistrated = true;
			e.caller = script;

			Debug.Log(m_Instance.Events);
			Debug.Log(e);


			EventManager.m_Instance.Events.Add ( e );

			return e;

		}

		/// <summary>
		/// Unregisters the event.
		/// </summary>
		/// <param name="EventName">Event name.</param>
		public static void UnregisterEvent(string EventName) {
			bool found = false;
			for ( int i = 0; i < m_Instance.Events.Count; i++ ) {
				if ( EventName == m_Instance.Events[i].name ) {
					m_Instance.Events [i].RemoveAllListerners ();
					m_Instance.Events.Remove ( m_Instance.Events [i] );
					found = true;
				}
			}
			if ( !found ) {
				Debug.LogError ( "EventName: " + EventName + " not found, i cant Unregister a event name that don't match with one of all events" );
			}
		}

		/// <summary>
		/// Unregisters the event.
		/// </summary>
		/// <param name="EventName">Event name.</param>
		/// <param name="EventCaller">Event caller.</param>
		public static void UnregisterEvent(string EventName, GameObject EventCaller) {
			bool found = false;
			for ( int i = 0; i < m_Instance.Events.Count; i++ ) {
				if ( EventName == m_Instance.Events[i].name && EventCaller.gameObject.GetHashCode() == m_Instance.Events[i].caller.gameObject.GetHashCode() ) {
					m_Instance.Events [i].RemoveAllListerners ();
					m_Instance.Events.Remove ( m_Instance.Events [i] );
					found = true;
				}
			}
			if ( !found ) {
				Debug.LogError ( "EventName: " + EventName + " not found, i cant Unregister a event name that don't match with one of all events" );
			}
		}


		/// <summary>
		/// Unregisters the event.
		/// </summary>
		/// <param name="EventName">Event name.</param>
		/// <param name="EventCaller">Event caller.</param>
		public static void UnregisterEvent(string EventName, Behaviour EventCaller) {
			bool found = false;
			for ( int i = 0; i < m_Instance.Events.Count; i++ ) {
				if ( EventName == m_Instance.Events[i].name && EventCaller.GetHashCode() == m_Instance.Events[i].caller.GetHashCode() ) {
					m_Instance.Events [i].RemoveAllListerners ();
					m_Instance.Events.Remove ( m_Instance.Events [i] );
					found = true;
				}
			}
			if ( !found ) {
				Debug.LogError ( "EventName: " + EventName + " not found, i cant Unregister a event name that don't match with one of all events" );
			}
		}

		/// <summary>
		/// Unregisters all events.
		/// </summary>
		public static void UnregisterAllEvents() {
			for ( int i = 0; i < m_Instance.Events.Count; i++ ) {
				m_Instance.Events [i].RemoveAllListerners ();
			}

			m_Instance.Events.Clear ();
		}

		/// <summary>
		/// Gets a event.
		/// </summary>
		/// <returns>The event.</returns>
		/// <param name="EventName">Event name.</param>
		public static DuckalotEvent GetEvent(string EventName) {
			for ( int i = 0; i < m_Instance.Events.Count; i++ ) {

				if ( EventName == m_Instance.Events[i].name ) {
					return m_Instance.Events [i];
				}
			}

			Debug.LogError ( "EventName not found " + EventName + " did you spell it correct?" );
			return null;
		}

		/// <summary>
		/// Gets a event on a special GameObject.
		/// </summary>
		/// <returns>The event.</returns>
		/// <param name="EventCaller">The Event Caller</param>
		public static DuckalotEvent GetEvent(string EventName, GameObject EventCaller) {
			for ( int i = 0; i < m_Instance.Events.Count; i++ ) {

				if ( EventName == m_Instance.Events[i].name && EventCaller.GetHashCode() == m_Instance.Events[i].caller.gameObject.GetHashCode() ) {
					return m_Instance.Events [i];
				}
			}

			Debug.LogError ( "EventName not found " + EventName + " did you spell it correct? || Or does the caller: " + EventCaller.name + " ist the same?" );
			return null;
		}

		/// <summary>
		/// Gets a event on a special Behaviour.
		/// </summary>
		/// <returns>The event.</returns>
		/// <param name="EventCaller">The Event Caller</param>
		public static DuckalotEvent GetEvent(string EventName, Behaviour EventCaller) {
			for ( int i = 0; i < m_Instance.Events.Count; i++ ) {

				if ( EventName == m_Instance.Events[i].name && EventCaller.GetHashCode() == m_Instance.Events[i].caller.GetHashCode() ) {
					return m_Instance.Events [i];
				}
			}

			Debug.LogError ( "EventName not found " + EventName + " did you spell it correct? || Or does the caller: " + EventCaller.name + " ist the same?" );
			return null;
		}
	}
}