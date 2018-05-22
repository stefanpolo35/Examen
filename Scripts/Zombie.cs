using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {
	public float speed;
	public float rotationSpeed = 100.0F;

	Animator animZombie;
	// Use this for initialization
	void Start ()
	{
		animZombie = GetComponent <Animator>();	
	}
	
	// Update is called once per frame
	void Update ()
	{
		//zombie begint met lopen
		if (Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			animZombie.SetTrigger ("Walk");
			speed = 0.5f;
		}
		//zombie stopt met lopen
		if (Input.GetKeyUp (KeyCode.UpArrow)) 
		{
			animZombie.SetTrigger ("WalkStop");
		}
		//zombie begint met achteruit lopen
		if (Input.GetKeyDown(KeyCode.DownArrow)) 
		{
			animZombie.SetTrigger ("Walk");
			speed = 0.5f;
		}
		//zombie stopt met achteruit lopen
		if (Input.GetKeyUp(KeyCode.DownArrow)) 
		{
			animZombie.SetTrigger ("WalkStop");
		}
		//zombie begint met aanvallen
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			animZombie.SetTrigger ("Attack");

		}
		//zombie stopt met aanvallen
		if (Input.GetKeyUp (KeyCode.Space)) 
		{
			animZombie.SetTrigger ("AttackStop");
		}


		//zombie begint met rennen
		if (Input.GetKeyDown (KeyCode.LeftShift)) 
		{
			animZombie.SetTrigger ("Run");
			speed = 2f;
		}
		//zombie stopt met rennen
		if (Input.GetKeyUp (KeyCode.LeftShift)) 
		{
			animZombie.SetTrigger ("RunStop");
			speed = 0.5f;
		}

		//Bewegen voor- en achteruit
		float translation = Input.GetAxis ("Vertical") * speed;
		translation *= Time.deltaTime;
		transform.Translate(0, 0, translation);

		//Rondkijken
		float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
		rotation *= Time.deltaTime;
		transform.Rotate(0, rotation, 0);
	}

}


