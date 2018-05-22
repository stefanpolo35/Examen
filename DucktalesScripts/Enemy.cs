using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	float xSpeed;

	// Use this for initialization
	void Start () 
	{
		xSpeed = 0.7f;

	}
	

	void Update () 
	{
		//hier laat ik de enemy automatisch lopen
		transform.Translate (xSpeed * Time.deltaTime, 0, 0);
	}
	void OnTriggerEnter(Collider other)
	{
		//waarneer die de muuur met de teag muurRechts aanraakt dan moet die met de snelheid -0.7f gaan lopen
		if (other.gameObject.tag == "muurRechts") 
		{
			xSpeed = -0.7f;

		}
		//waarneer die de muuur met de teag muurLinks aanraakt dan moet die met de snelheid 0.7f gaan lopen
		if (other.gameObject.tag == "muurLinks") 
		{
			xSpeed = 0.7f;
		}
	}
}
