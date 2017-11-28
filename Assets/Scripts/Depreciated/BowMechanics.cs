using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Godliness {
public class BowMechanics : MonoBehaviour
{
	public string reloadName;
	public string weaponName;

	public float weaponPower = 0f;
	public float weaponDamage = 20f;

	public int magazineAmmount = 5;
	public int ammoInInventory;
	public int maxAmmoInMag = 1;
	public int currentAmmo;
	public float reloadTime = 1f;

	public bool isShoot = false;

	public bool isReloading = false;
	public bool isClick = false;
	public bool isOrbit = false;
	private bool haveAmmo = true;
	public GameObject Bullet;
	public GameObject BowArrow;
	public Animator animator;
	public AudioSource audio;
	public AudioSource empty;
	public Transform Barrel;

	public Fox.Flow.PlayerCamera OrbitCamera;
		public Fox.Flow.KeyMamager m_Keys;

	//Referencing the Camera to cam
	[SerializeField]
	private Camera cam;

	//Allows us to add different objects to different layers so bullets only hit other players
	[SerializeField]
	private LayerMask mask;

	// Use this for initialization
	void Start()
	{
		Bullet = Resources.Load ("Bullet") as GameObject;
		ammoInInventory = maxAmmoInMag * magazineAmmount;
			

			OrbitCamera = Fox.Flow.PlayerCamera.m_Instance;
			m_Keys = Fox.Flow.KeyMamager.m_Instance;

		//Checking if a camera is asigned
		if (cam == null)
		{
			//Throwing an error since there is no camera referenced
			Debug.LogError("No camera referenced!");
		}

		//when the game starts, set the current ammo equal to the max ammo
		currentAmmo = maxAmmoInMag;
		//        isScoping = animator.GetBool("Scoped");

	}


	//if script gets enabled make sure you cancel reloading, so if you switch weapons, it stops reloading
	void OnEnable()
	{
		isReloading = false;
		animator.SetBool(reloadName, false);
	}

	// Update is called once per frame
	void Update()
	{
			if (OrbitCamera.m_CameraViewMode == Fox.Flow.CameraViewMode.ORBIT) {
				isOrbit = true;
			} else if (OrbitCamera.m_CameraViewMode == Fox.Flow.CameraViewMode.THIRD_PERSON){
				isOrbit = false;
			}

		if (haveAmmo == true) {
			BowArrow.SetActive (true);
		}
		if (haveAmmo == false) {
			BowArrow.SetActive (false);
		}

			if(Input.GetKeyDown(m_Keys.m_MouseLeft.m_Keycode)){
			isClick = false;
		}
		else if (Input.GetButtonDown("Fire1")){
				isClick = true;
			}
		weaponDamage = .75f * weaponPower;


		if (currentAmmo <= 0f) {
			haveAmmo = false;
		}

		if (Input.GetButtonUp("Fire1") && weaponPower > 0 && haveAmmo == true && isReloading == false){
			Shoot ();
			weaponPower = 0;
		}

			if(Input.GetButton ("Fire1") && weaponPower < 100 && haveAmmo == true && isOrbit == false){
				weaponPower = weaponPower + 1;
				//set set the next time to fire equal to the fire rate
			}
			



			

		//Make sure not to do anything while reloading
		if (isReloading) {
			return;
		}
		//if gun has no ammo, start a coroutine. 


		//if R gets pressed, start the coroutine Reload()
		if (Input.GetKeyDown (KeyCode.R)) {
			StartCoroutine (Reload ());
			isReloading = true;
			return;
		}
		//if left mousebutton gets clicked and you can fire again and you have ammo, call the method Shoot()
	}
		
	//A coroutine is a method which can be paused at any time
	IEnumerator Reload ()
	{
		isReloading = true;



		//Make sure not to reload when mag is full 
		if(currentAmmo == maxAmmoInMag)
		{
			yield return 0;
		}
		/*else if (!isScoping)
        {
            yield return 0;
        }*/


		//if R is pressed and if you have ammo left in your inventory 
		if (Input.GetKeyDown(KeyCode.R) && ammoInInventory >= 0)
		{
			animator.SetBool ("Scoped", false);
			animator.SetBool(reloadName, true);
			StartCoroutine ("Rel");
			//Wait reloadTime seconds
			yield return new WaitForSeconds(reloadTime);

			Debug.Log("Reloading! TODO better reload animation here");


			//if you have more ammo in your inv then in you can have in your gun, just set them equal
			//else set the current ammo equal to the ammoInInventory since it will always be less then maxAmmoInMag
			if (ammoInInventory >= maxAmmoInMag - currentAmmo)
			{
				ammoInInventory -= maxAmmoInMag - currentAmmo;
				currentAmmo = maxAmmoInMag;

			}

		}
		animator.SetBool(reloadName, false);
		haveAmmo = true;
		isReloading = false;

	}


	void Shoot()
	{

		//Play the muzzleflash


		audio.Play ();

		GameObject Projectile = Instantiate (Bullet) as GameObject;
		Projectile.transform.position = Barrel.position;
		Projectile.transform.rotation = Barrel.rotation;
		Rigidbody Rigid = Projectile.GetComponent<Rigidbody> ();
		Rigid.velocity = Camera.main.transform.forward * weaponPower;




		currentAmmo--;

		//Creating a new Raycast under the name _hit


		//if the raycast hits something in the weapons range

	}


	//sending a message to the console that the bullet hit something









	IEnumerator Rel (){
		yield return new WaitForSeconds (.5f);
	}
}
}