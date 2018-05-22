using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deur : MonoBehaviour 
{
	Animator animatie;

	// Use this for initialization
	void Start ()
	{
		animatie = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			animatie.SetTrigger ("open");
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")  
		{
			animatie.SetTrigger ("dicht");
		}
	}
}
