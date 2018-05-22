using UnityEngine;
using System.Collections;

public class EnemyR : MonoBehaviour  {

	public float FPS;
	public Texture[] frames;
	private float secWachttijd;
	private int huidigFrame;
	public bool herhaal;
	public bool rechts;
	public bool rechts1;

	void Start () 
	{
		huidigFrame = 0;
		secWachttijd = 1 /FPS;

		rechts = false;
		rechts1 = false;
	}

	void Update()
	{
		//wanneer de boolean rechts true is start die de animatie en zet die de variable true op false
		if (rechts == true)
		{
			StartCoroutine (AnimatieRoutine ());
			rechts = false;
		}
	}

	IEnumerator AnimatieRoutine()
	{
		//hier maak ik de boolean stoppen aan en zet hem op false
		bool stoppen = false;


			if (huidigFrame >= frames.Length) {
				
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

			GetComponent<Renderer> ().material.mainTexture = frames [huidigFrame];
			huidigFrame++;

		if (!stoppen && rechts1 == true) {
				StartCoroutine (AnimatieRoutine ());
			}

	}
	void OnTriggerEnter(Collider other)
	{
		//als die de rechter muur aanraakt dan gaat rechts true
		if (other.gameObject.tag == "muurRechts") 
		{
			rechts = true;
			rechts1 = true;
		}
		//als die de linker muur raakt zet je rechts false
		if (other.gameObject.tag == "muurLinks") 
		{
			rechts = false;
			rechts1 = false;
		}
	}
}