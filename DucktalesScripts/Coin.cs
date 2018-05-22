using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {
	//hier maak ik de variable aan
	public float FPS;
	public Texture[] frames;
	private float secWachttijd;
	private int huidigFrame;
	public bool herhaal;

	void Start () 
	{
		huidigFrame = 0;
		// de wachtijd tussen de frames in
		secWachttijd = 1 /FPS;
		//hier start de animatie
		StartCoroutine (AnimatieRoutine ());
	}

	//hier start je de animatie
	IEnumerator AnimatieRoutine()
	{
		//hier maak ik de bool stoppen aan en zet hem gelijk op false
		bool stoppen = false;

		//als huidig frame dan de totale frames dan stopt die de animatie 
		if (huidigFrame >= frames.Length) 
		{
			//wanneer herhaal false is dan laat die de animatie stoppen 
			if (!herhaal) 
			{
				stoppen = true;
			} 
			//en anders laat die hem naar frame 0 gaan
			else 
			{
				huidigFrame = 0;
			}
		}
		// deze functie gebruiken we om de animatie te laten pauzeren
		yield return new WaitForSeconds (secWachttijd);

		//uit de component vraag je de main texture op en zegt dat dat dan het huidige frame is
		GetComponent<Renderer>().material.mainTexture = frames [huidigFrame];

		huidigFrame++ ;
		//wanneer stoppen false is dan start de animatie
		if (!stoppen) 
		{
			StartCoroutine (AnimatieRoutine ());
		}

	}
	void OnTriggerEnter(Collider other)
	{
		//als je de munt pakt gaat die weg
		if (other.gameObject.tag == "Coin") 
		{
			Destroy (other.gameObject);

		}
	}
}