
using UnityEngine;

public class Gun : MonoBehaviour {
	public float damage = 10f;
	public float range = 100f;
	public float fireRate = 15f;
	public float impactForce = 30f;

	public Camera fpsCam;
	public ParticleSystem muzzleFlash;
	public GameObject impactEffect;

	private float nextTimetoFire = 0f;

	// Update is called once per frame
	void Update ()
	{
		//schieten
		if (Input.GetButton ("Fire1") && Time.time >= nextTimetoFire)
		{
			nextTimetoFire = Time.time + 1f / fireRate;
			//verwijst naar de functie Shoot
			Shoot();
		}
	}
	void Shoot()
	{
		//zorgt dat het particlesysteem gaat afspelen
		muzzleFlash.Play();

		//wanneer je iets raakt
		RaycastHit hit;
		if (Physics.Raycast (fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) 
		{
			Debug.Log (hit.transform.name);

			//zoekt het object target
			Volgen target = hit.transform.GetComponent<Volgen> ();
			//wanneer je iets anders raakt dan het object Target
			if (target != null) 
			{
				target.TakeDamage(damage);
			}

			if (hit.rigidbody != null) 
			{
				hit.rigidbody.AddForce (-hit.normal * impactForce);
			}

			//zorgt ervoor dat het impact effect aankomt waar je naar toe kijkt
			GameObject impactGO = Instantiate (impactEffect, hit.point, Quaternion.LookRotation (hit.normal));
			//verwijderd het impact effect na 2 seconden
			Destroy (impactGO, 2f);
		}
	}
}
