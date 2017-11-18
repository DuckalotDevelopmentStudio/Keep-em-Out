using UnityEngine;
using System;
using UnityEngine.Events;
using System.Collections.Generic;

namespace Project.Managers {
	[Serializable]
	/// <summary>
	/// Duckalot event. to add and remove listerners and also to Invoke the event
	/// </summary>
	public class DuckalotEvent {

		/// <summary>
		/// The name of the Event.
		/// </summary>
		 public string name = "Event";

		/// <summary>
		/// The caller script.
		/// </summary>
		public Behaviour caller;

		/// <summary>
		/// Is the event activ?.
		/// </summary>
		public bool active = false;

		/// <summary>
		/// Have the Event listeners?.
		/// </summary>
		public bool haveListeners = false;

		/// <summary>
		/// The listerners.
		/// </summary>
		public List<DuckalotListerner> listerners = new List<DuckalotListerner> ();

		/// <summary>
		/// Is registrated with the EventManger?.
		/// </summary>
		public bool isRegistrated = false;

		/// <summary>
		/// The event.
		/// </summary>
		public UnityEvent Event = new UnityEvent ();


		/// <summary>
		/// Adds a listerner.
		/// </summary>
		/// <param name="function">Function you want to listen</param>
		/// <param name="listernerName">The name of the Listerner be creative.</param>
		public void AddListerner(Action function, string listernerName) {
			if ( isRegistrated ) {
				DuckalotListerner l = new DuckalotListerner ();
				l.function = function;
				l.name = listernerName;

				listerners.Add(l);

				haveListeners = true;


				Event.AddListener ( delegate {
					
					active = true;

					function();

					active = false;
				} );
			} else {
				Debug.LogError("You need register the event with the name " + name + ", first bevore you can call AddListerner( Action function, string functionName )");
			}
		}

		/// <summary>
		/// Invoke this Event.
		/// </summary>
		public void Invoke() {
			if ( isRegistrated ) {
				if ( listerners.Count > 0 ) {
					Event.Invoke ();
				} else {
					Debug.Log ( "You have no Event Function to Invoke, add your function first with AddListerner( Action function, string functionName )" );
				}
			} else {
				Debug.LogError("You need register the event with the name " + name + ", first bevore you can call Invoke()");
			}
		}

		/// <summary>
		/// Removes the listerner from the Event.
		/// </summary>
		/// <param name="listernerNameToRemove">Listerner name to call the remove.</param>
		public void RemoveListerner(string listernerNameToRemove) {
			if ( isRegistrated ) {
				if ( listerners.Count > 0 ) {
					bool found = false;
					for ( int i = 0; i < listerners.Count; i++ ) {
						if ( listernerNameToRemove == listerners[i].name ) {
							listerners.Remove ( listerners [i] );
							found = true;
						}
					}

					if ( !found ) {
						Debug.LogError("Cant found the listerner Name " + listernerNameToRemove + " do you spell it correct?");
						return;
					}

					Event.RemoveAllListeners ();

					if ( listerners.Count > 0 ) {

						List<DuckalotListerner> l = new List<DuckalotListerner> ();
						for ( int i = 0; i < listerners.Count; i++ ) {
							l.Add ( listerners [i] );
						}
						listerners.Clear ();

						for ( int i = 0; i < l.Count; i++ ) {
							AddListerner ( l[i].function, l [i].name );
						}

					} else {
						haveListeners = false;
					}

				} else {
					Debug.Log ( "No Function to remove! Because you don't have listerners" );
				}
			} else {
				Debug.LogError("You need register the event with the name " + name + ", first bevore you can call RemoveListerner( string listernerNameToRemove )");
			}
		}

		/// <summary>
		/// Removes all listerners from this Event.
		/// </summary>
		public void RemoveAllListerners() {
			if ( isRegistrated ) {
				listerners.Clear ();
				Event.RemoveAllListeners ();
				haveListeners = false;
			} else {
				Debug.LogError("You need register the event with the name " + name + ", first bevore you can call RemoveAllListerners()");
			}
	
		}
	}
}