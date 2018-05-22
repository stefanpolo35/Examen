using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volgen : MonoBehaviour {
	public Transform player;
	Animator anim;
	public GameObject spelertje;
	float levens = 5;
	string state = "patrol";
	public GameObject[] waypoints;
	public float health = 50f;
	int currentWP = 0;
	float rotSpeed = 0.2f;
	float speed = 1.5f;
	float accuracyWP = 5.0f;
	Vector3 startpositie;

	// Use this for initialization
	void Start () 
	{
		//connectie maken met de Animator
		anim = GetComponent<Animator> ();	
		startpositie = new Vector3 (106.29f, 0.915f, 72.7f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 direction = player.position - this.transform.position;

		//wanneer die de waypoints volgt zorgt die dat de walk animatie afspeelt
		if (state == "patrol" && waypoints.Length > 0) 
		{
			anim.SetBool ("Idle", false);
			anim.SetBool ("Walk", true);
		//verplaatsen van het object naar de waypoints toe
			if (Vector3.Distance (waypoints [currentWP].transform.position, transform.position) < accuracyWP) 
			{
				currentWP++;
				if (currentWP >= waypoints.Length) 
				{
					currentWP = 0;
				}
			}
		
		
			//zorgt ervoor dat die richting de waypoint toeloopt
			direction = waypoints [currentWP].transform.position - transform.position;
			//zorgt ervoor dat die richting de waypoint kijkt
			this.transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), rotSpeed * Time.deltaTime);
			this.transform.Translate (0, 0, Time.deltaTime * speed);
		}
		//als je in de buurt komt dan volgt de vijand je
		if (Vector3.Distance (player.position, this.transform.position) < 5 || state == "pursuing") 
		{

			state = "pursuing";
			direction.y = 0;
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.1f);


			//wanneer de afstand tussen de player en de vijand boven de 5 is dan volgt de vijand je
			if (direction.magnitude >  5) 
			{
				
				this.transform.Translate (0, 0, 0.05f);
				anim.SetBool ("Walk", true);
				anim.SetBool ("Attack", false);
			}
			
			//als de afstand kleiner is dan 5 begint de vijand aan te vallen
			else 
			{
				StartCoroutine (slaan ());

			}

		}
		//wanneer de vijand je kwijt is dan gaat die weer terug naar de waypoints
		else
		{
			
			anim.SetBool ("Walk", true);
			anim.SetBool ("Attack", false);
			state = "patrol";
		}
	}
	IEnumerator slaan ()
	{
		anim.SetBool ("Attack", true);
		anim.SetBool ("Walk", false);
		yield return new WaitForSeconds (1.2f);
		spelertje.transform.position = startpositie;
	}

	public void TakeDamage (float amount)
	{
		health -= amount;
		//wanneer levens 0 is verwijst die naar de functie Die
		if (health <= 0f) 
		{
			Die();
		}

	}
	//als de levens op zijn verwijdert die het object
	void Die ()
	{
		speed = 0;
		anim.SetTrigger ("Die");
		Destroy(gameObject, 2.8f);
	}
}
