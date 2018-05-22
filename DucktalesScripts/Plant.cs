using UnityEngine;
using System.Collections;

public class Plant : MonoBehaviour {

	public float FPS;
	public Texture[] frames;
	private float secWachttijd;
	private int huidigFrame;
	public bool herhaal;
	bool plant;
	bool stoppen = false;

	void Start () 
	{
		huidigFrame = 0;
		secWachttijd = 1 /FPS;

		plant = false;
	}
	void Update()
	{
		if (plant == true) 
		{
			plant = false;
			StartCoroutine (AnimatieRoutine ());
		}
	}

	IEnumerator AnimatieRoutine()
	{
		stoppen = false;

		if (huidigFrame >= frames.Length) 
		{
			if (!herhaal) 
			{
				stoppen = true;
			} 
			else 
			{
				huidigFrame = 0;
			}
		}

		yield return new WaitForSeconds (secWachttijd);

		GetComponent<Renderer>().material.mainTexture = frames [huidigFrame];
		huidigFrame++ ;

		if (!stoppen) 
		{
			StartCoroutine (AnimatieRoutine ());
		}

	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Speler") 
		{

			plant = true;

		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == "Speler") 
		{

			stoppen = true;

		}
	}
}