using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stilstaand : MonoBehaviour {

	public Transform player;
	Animator anim;

	public GameObject spelertje;

	float rotSpeed = 0.2f;
	float speed = 1.5f;
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
		
		//float angle = Vector3.Angle (direction, this.transform.forward);
		if (Vector3.Distance (player.position, this.transform.position) < 20) 
		{
			Vector3 direction = player.position - this.transform.position;
			direction.y = 0;
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.1f);

			anim.SetBool ("isIdle", false);
			if (direction.magnitude > 5) 
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

			anim.SetBool ("isIdle", true);
			anim.SetBool ("isWalking", false);
			anim.SetBool ("isAttacking", false);

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
