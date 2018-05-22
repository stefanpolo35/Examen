using UnityEngine;
using System.Collections;

public class Lopen : MonoBehaviour {
	Animator lopen;
	public float snelheid;
	public float draaisnelheid;
	bool stop;
	public GameObject spin;
	public GameObject neushoorn;
	public GameObject tijger;
	public GameObject chomp;
	public GameObject monster;
	public GameObject golem;


	// Use this for initialization
	void Start () 
	{
		lopen = GetComponent <Animator> ();
	
	}
	

	void Update () 
	{
		//Veranderingen van de dieren
		if (Input.GetKeyDown(KeyCode.Alpha1)) 
		{
			var verander = (GameObject)Instantiate (monster, new Vector3 ( transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
			Destroy (gameObject);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2)) 
		{
			var verander = (GameObject)Instantiate (neushoorn, new Vector3 ( transform.position.x, transform.position.y + 2, transform.position.z), Quaternion.identity);
			Destroy (gameObject);

		}
		else if (Input.GetKeyDown(KeyCode.Alpha3)) 
		{
			var verander = (GameObject)Instantiate (tijger, new Vector3 ( transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
			Destroy (gameObject);

		}
		else if (Input.GetKeyDown(KeyCode.Alpha4)) 
		{
			var verander = (GameObject)Instantiate (chomp, new Vector3 ( transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
			Destroy (gameObject);

		}
		else if (Input.GetKeyDown(KeyCode.Alpha5)) 
		{
			var verander = (GameObject)Instantiate (spin, new Vector3 ( transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
			Destroy (gameObject);

		}
		else if (Input.GetKeyDown(KeyCode.Alpha6)) 
		{
			var verander = (GameObject)Instantiate (golem, new Vector3 ( transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
			Destroy (gameObject);

		}

	
		if (Input.GetKey(KeyCode.UpArrow)) 
		{
			transform.Rotate (0, Input.GetAxis ("Horizontal") *draaisnelheid * Time.deltaTime, 0);
			transform.position += transform.forward * snelheid * Time.deltaTime;
			stop = true;
			lopen.SetBool ("Lopen", stop);
		}
		if (Input.GetKey(KeyCode.DownArrow)) 
		{
			transform.Rotate (0, Input.GetAxis ("Horizontal") * draaisnelheid * Time.deltaTime, 0);
			transform.position += transform.forward * -snelheid * Time.deltaTime;
			stop = true;
			lopen.SetBool ("Lopen", stop);
		}
		if (Input.GetKeyUp(KeyCode.UpArrow)) 
		{
			stop = false;
			lopen.SetBool ("Lopen", stop);
		}
		if (Input.GetKeyUp(KeyCode.DownArrow)) 
		{
			stop = false;
			lopen.SetBool ("Lopen", stop);
		}
		if (Input.GetKeyUp(KeyCode.Space)) 
		{
			lopen.SetTrigger ("Slaan");
		}
		if (Input.GetMouseButtonDown(0))
		{
			lopen.SetTrigger ("Slaan2");
		}

		if (Input.GetKeyDown(KeyCode.F)) 
		{
			GetComponent<Animator>().SetBool("Flame", true);
		}
		if (Input.GetKeyUp(KeyCode.F))  
		{
			GetComponent<Animator>().SetBool("Flame", false);
		}



	}

	void OnCollisionEnter (Collision other) {
		if (other.gameObject.tag == "muurCol")
		{
			if (this.gameObject == neushoorn)
			{

				Destroy (other.gameObject);
			}
	
		}

	}
		


}
