using UnityEngine;
using Project.Managers;

namespace Fox.Flow {
	public class Example : MonoBehaviour {

		// The event will be stored in a variable so that we can access them everytime
		private DuckalotEvent TheEvent;
		
		
		void Start () {

			// Register the event, this function will make a instance and also fill out your event variable
			TheEvent = EventManager.RegisterEvent ( "ExampleEvent", this );

			// Add your function in the event like i did and pick a Listerner name to hold it organized
			TheEvent.AddListerner ( MyFunction, "SpartaFunction" );

			// Activate the event where you want
			TheEvent.Invoke ();
		}
		
	
		void MyFunction() {
			Debug.Log ( "This is SPARTA!" );
		}
	}
}