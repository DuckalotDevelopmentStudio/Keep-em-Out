using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Project.Managers {
	/// <summary>
	/// Save manager to save files and load files, all data gets seperate in one special file to keep the level of loaded data low and to make the system more flexible
	/// </summary>
	public class SaveManager : MonoBehaviour {
		

		#region Singleton from SaveManager
		public static SaveManager m_Instance;
		#endregion

		/// <summary>
		/// The save path of the files (will be changed at runtime).
		/// </summary>
		public static string SavePath;
		/// <summary>
		/// The name of the save folder.
		/// </summary>
		public string SaveFolderName = "data";
		/// <summary>
		/// The file endings.
		/// </summary>
		public string FileEndings = ".duckalot";

		private Guid id;

		void Awake () {
			#region Singleton from SaveManager
			if (m_Instance != null) {
				Debug.LogError("More then 1 instance found " + m_Instance.name);
				return;
			}
			m_Instance = this;
			#endregion

			SavePath = Application.persistentDataPath + "/" + SaveFolderName;

			if ( !Directory.Exists(SavePath) ) {
				Directory.CreateDirectory ( SavePath );
			}

			Debug.Log ("Save-Files get Loaded/Saved at: " + SavePath );

			int i = 57835;

			Save ( i, "Test Key" );
			var v = (int)Load ( "Test Key" );
			Debug.Log ( v );
		}


		/// <summary>
		/// Save specified data, to find your data again you need to type a key \n
		/// you save a float like this way\n
		/// SaveManager.Save(myFloat, "MyKey");
		/// </summary>
		/// <param name="data">Your Data you want so save, it can be all kinds of data, int, float, Lists, custom classes, arrays and more...</param>
		/// <param name="key">Your Key to finally find your data again</param>
		public static void Save(object data, string key) {
			SaveManager.m_Instance.id = Guid.NewGuid ();
			string fileName = SaveManager.m_Instance.id.ToString ();

			if ( !DataExist(key) ) {
				BinaryFormatter bFormat = new BinaryFormatter ();
				using ( FileStream fStream = File.Create ( SavePath + "/" + fileName + SaveManager.m_Instance.FileEndings ) ) {

					DuckalotSave save = new DuckalotSave ();

					using ( var memoryStream = new MemoryStream () ) {
						bFormat.Serialize(memoryStream, data);
						memoryStream.Flush();
						memoryStream.Position = 0;
						string value = Convert.ToBase64String(memoryStream.ToArray());
						save.data = value;
					}

					var keyBytes = System.Text.Encoding.UTF8.GetBytes(key);
					save.key = System.Convert.ToBase64String ( keyBytes );

					bFormat.Serialize ( fStream, save );

					fStream.Close ();
				}
			} else {
				DirectoryInfo d = new DirectoryInfo ( SavePath );
				FileInfo[] files = d.GetFiles ( "*" + SaveManager.m_Instance.FileEndings, SearchOption.TopDirectoryOnly );

				BinaryFormatter bFormat = new BinaryFormatter ();

				for ( int i = 0; i < files.Length; i++ ) {

					using ( FileStream fStream = files [i].Open ( FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite ) ) {

						DuckalotSave s = ( DuckalotSave )bFormat.Deserialize ( fStream );

						var deserializedKey = System.Convert.FromBase64String ( s.key );

						if ( key == System.Text.Encoding.UTF8.GetString( deserializedKey ) ) {

							fStream.Close ();

							files [i].Delete ();

							using ( FileStream fileStream = File.Create ( SavePath + "/" + fileName + SaveManager.m_Instance.FileEndings ) ) {

								DuckalotSave save = new DuckalotSave ();

								using ( var memoryStream = new MemoryStream () ) {
									bFormat.Serialize(memoryStream, data);
									memoryStream.Flush();
									memoryStream.Position = 0;
									string value = Convert.ToBase64String(memoryStream.ToArray());
									save.data = value;
								}

								var keyBytes = System.Text.Encoding.UTF8.GetBytes(key);
								save.key = System.Convert.ToBase64String ( keyBytes );

								bFormat.Serialize ( fileStream, save );

								fileStream.Close ();
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// Load specified data \n
		/// You can load everything you saved when you use the correct key\n
		/// to load a float use this \n
		/// float myFloat = (float)SaveManager.Load("MyKey");
		/// </summary>
		/// <param name="key">Your Key to finally find your data</param>
		public static object Load(string key) {
			DirectoryInfo d = new DirectoryInfo ( SavePath );
			FileInfo[] files = d.GetFiles ( "*" + SaveManager.m_Instance.FileEndings, SearchOption.TopDirectoryOnly );

			BinaryFormatter bFormat = new BinaryFormatter ();

			for ( int i = 0; i < files.Length; i++ ) {

				using ( FileStream fStream = files [i].Open ( FileMode.Open, FileAccess.Read, FileShare.ReadWrite ) ) {

					DuckalotSave s = ( DuckalotSave )bFormat.Deserialize ( fStream );

					var deserializedKey = System.Convert.FromBase64String ( s.key );

					if ( key == System.Text.Encoding.UTF8.GetString( deserializedKey ) ) {

						fStream.Close ();

						byte[] mData = System.Convert.FromBase64String ( s.data );

						return RawDeserializer(mData);
					}
				}

			}
			Debug.LogError ( "File with the key: " + key + " NOT found, check if the file exist or check your key spelling" );
			return null;
		}

		/// <summary>
		/// Checks if the file exist true = Data Exist, false = Data not exist
		/// </summary>
		/// <returns><c>true</c>, if the file exist, <c>false</c> otherwise.</returns>
		/// <param name="key">The Key for the data you looking for.</param>
		public static bool DataExist(string key) {
			DirectoryInfo d = new DirectoryInfo ( SavePath );
			FileInfo[] files = d.GetFiles ( "*" + SaveManager.m_Instance.FileEndings, SearchOption.TopDirectoryOnly );

			BinaryFormatter bFormat = new BinaryFormatter ();

			for ( int i = 0; i < files.Length; i++ ) {

				using ( FileStream fStream = files [i].Open ( FileMode.Open, FileAccess.Read, FileShare.ReadWrite ) ) {
					DuckalotSave s = ( DuckalotSave )bFormat.Deserialize ( fStream );

					var deserializedKey = System.Convert.FromBase64String ( s.key );

					if ( key == System.Text.Encoding.UTF8.GetString( deserializedKey ) ) {
						fStream.Close ();
						return true;
					}
				}

			}
			return false;
		}

		public static byte[] RawSerializer(object _object)
		{   
			byte[] bytes;
			using (var _MemoryStream = new MemoryStream())
			{
				BinaryFormatter _BinaryFormatter = new BinaryFormatter();
				_BinaryFormatter.Serialize(_MemoryStream, _object);
				bytes = _MemoryStream.ToArray();
				_MemoryStream.Close ();
			}
			return bytes;
		}

		public static object RawDeserializer(byte[] _byteArray)
		{   
			object o = new object ();
			using (var _MemoryStream = new MemoryStream(_byteArray))
			{
				BinaryFormatter _BinaryFormatter = new BinaryFormatter();
				o = ( object )_BinaryFormatter.Deserialize(_MemoryStream); 
				_MemoryStream.Close ();
			}
			return o;
		}
	}
}