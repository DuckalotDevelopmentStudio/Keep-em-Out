using System;
using UnityEngine;

namespace Project.Managers {
	[Serializable]
	/// <summary>
	/// Duckalot listerner.
	/// </summary>
	public class DuckalotListerner
	{

		/// <summary>
		/// The name of the listerner.
		/// </summary>
		public string name;
		/// <summary>
		/// The function you want to listen.
		/// </summary>
		public Action function;

		public Behaviour caller;
	}
}