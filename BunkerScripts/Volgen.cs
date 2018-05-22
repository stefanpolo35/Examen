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
	int currentWP = 0;
	float rotSpeed = 0.2f;
	float speed = 1.5f;
	float accuracyWP = 5.0f;
	Vector3 startpositie;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();	
		startpositie = new Vector3 (106.29f, 0.915f, 72.7f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 direction = player.position - this.transform.position;

		if (state == "patrol" && waypoints.Length > 0) 
		{
			anim.SetBool ("isIdle", false);
			anim.SetBool ("isWalking", true);
			if (Vector3.Distance (waypoints [currentWP].transform.position, transform.position) < accuracyWP) 
			{
				currentWP++;
				if (currentWP >= waypoints.Length) 
				{
					currentWP = 0;
				}
			}
			direction = waypoints [currentWP].transform.position - transform.position;
			this.transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), rotSpeed * Time.deltaTime);
			this.transform.Translate (0, 0, Time.deltaTime * speed);
		}
		if (Vector3.Distance (player.position, this.transform.position) < 5 || state == "pursuing") 
		{

			state = "pursuing";
			direction.y = 0;
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.1f);


			if (direction.magnitude >  5) 
			{
				
				this.transform.Translate (0, 0, 0.05f);
				anim.SetBool ("isWalking", true);
				anim.SetBool ("isAttacking", false);
			}
			else 
			{
				StartCoroutine (slaan ());

			}

		}
		else
		{
			
			anim.SetBool ("isWalking", true);
			anim.SetBool ("isAttacking", false);
			state = "patrol";
		}
	}
	IEnumerator slaan ()
	{
		anim.SetBool ("isAttacking", true);
		anim.SetBool ("isWalking", false);
		yield return new WaitForSeconds (1.2f);
		spelertje.transform.position = startpositie;
	}
}
