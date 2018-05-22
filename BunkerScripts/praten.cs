using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;


public class praten : MonoBehaviour 
{
	public GameObject E;
	public GameObject gesprekbox;

	public Text gesprek;

	public string tekst;

	public float tijd;

	public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;

	// Use this for initialization
	void Start ()
	{
		tijd = 5;
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			E.SetActive (true);
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E)) 
		{
			E.SetActive (false);
			StartCoroutine (Praten ());
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			E.SetActive (false);
		}
	}

	IEnumerator Praten ()
	{
		controller.m_WalkSpeed = (0);
		controller.m_RunSpeed = (0);
		controller.m_JumpSpeed = (0);

		gesprekbox.SetActive (true);

		gesprek.text = "" + tekst;

		yield return new WaitForSeconds (tijd);
			controller.m_WalkSpeed = (5);
			controller.m_RunSpeed = (10);
			controller.m_JumpSpeed = (10);
			gesprekbox.SetActive (false);
			Destroy (this);
	}
}

