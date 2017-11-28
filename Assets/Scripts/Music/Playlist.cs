using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Playlist : MonoBehaviour {
	

	public AudioSource MusicPlayer;
	public AudioClip SongOne;
	public AudioClip SongTwo;
	public AudioClip SongThree;
	public AudioClip SongFour;
	public AudioClip SongFive;
	public AudioClip SongSix;
	public AudioClip SongSeven;
	public AudioClip SongEight;
	public AudioClip SongNine;
	public AudioClip SongTen;
	private int SongNumber;

	public Text SongName;
	// Use this for initialization
	void Start(){
		DontDestroyOnLoad(transform.gameObject);
		SongNumber = 1;
		StartCoroutine ("SongStart");
	}
	void Update(){
		SongName.text = "Playing: '" + MusicPlayer.clip.name + "'";
	}
	// Update is called once per frame
	IEnumerator SongStart () {



		if (SongNumber == 0) {
			SongNumber = 10;
		}
		if (SongNumber == 11) {
			SongNumber = 1;
		}

		if (SongNumber == 1) {
			MusicPlayer.clip = SongOne;
			MusicPlayer.Play();
			yield return new WaitForSeconds (MusicPlayer.clip.length);
			SongNumber++;
		}
		if (SongNumber == 2) {
			MusicPlayer.clip = SongTwo;
			MusicPlayer.Play();
			yield return new WaitForSeconds (MusicPlayer.clip.length);
			SongNumber++;
		}
		if (SongNumber == 3) {
			MusicPlayer.clip = SongThree;
			MusicPlayer.Play();
			yield return new WaitForSeconds (MusicPlayer.clip.length);
			SongNumber++;
		}
		if (SongNumber == 4) {
			MusicPlayer.clip = SongFour;
			MusicPlayer.Play();
			yield return new WaitForSeconds (MusicPlayer.clip.length);
			SongNumber++;
		}
		if (SongNumber == 5) {
			MusicPlayer.clip = SongFive;
			MusicPlayer.Play();
			yield return new WaitForSeconds (MusicPlayer.clip.length);
			SongNumber++;
		}
		if (SongNumber == 6) {
			MusicPlayer.clip = SongSix;
			MusicPlayer.Play();
			yield return new WaitForSeconds (MusicPlayer.clip.length);
			SongNumber++;
		}
		if (SongNumber == 7) {
			MusicPlayer.clip = SongSeven;
			MusicPlayer.Play();
			yield return new WaitForSeconds (MusicPlayer.clip.length);
			SongNumber++;
		}
		if (SongNumber == 8) {
			MusicPlayer.clip = SongEight;
			MusicPlayer.Play();
			yield return new WaitForSeconds (MusicPlayer.clip.length);
			SongNumber++;
		}
		if (SongNumber == 9) {
			MusicPlayer.clip = SongNine;
			MusicPlayer.Play();
			yield return new WaitForSeconds (MusicPlayer.clip.length);
			SongNumber++;
		}
		if (SongNumber == 10) {
			MusicPlayer.clip = SongTen;
			MusicPlayer.Play();
			yield return new WaitForSeconds (MusicPlayer.clip.length);
			SongNumber++;
		}
		if (MusicPlayer.clip == null && SongNumber != 0 && SongNumber != 11) {
			SongNumber++;
		}



	}
}
