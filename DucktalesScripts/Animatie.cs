using UnityEngine;
using System.Collections;

public class Animatie : MonoBehaviour {

	public float FPS;
	public Texture[] frames;
	private float secWachttijd;
	float Wachttijd;
	private int huidigFrame;
	public bool herhaal;
	public bool rechts;
	bool stoppen = false;

	void Start () 
	{
		//hier start je de animatie
		StartCoroutine (AnimatieRoutine ());
		//hier zeg je dat je animatie moet beginnen bij frame 0
		huidigFrame = 0;
		secWachttijd = 1 /FPS;
		rechts = false;
	}

	IEnumerator AnimatieRoutine()
	{
		//hier wordt gecontroleerd of er al een eind is gekomen aan de animatie
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
		//hier vraag je de huidige frame op van de animatie
		GetComponent<Renderer>().material.mainTexture = frames [huidigFrame];
		//hier zeg je dat je frame ++ 1 moet gaan
		huidigFrame++;



	}

	void Update ()
	{
		// als rechts false is dan moet die de animatie opnieuw opstarten
		if (rechts == false) {

			if (Wachttijd > 0.1f) 
			{
				if (!stoppen) {
					StartCoroutine (AnimatieRoutine ());
				}
				Wachttijd = 0;
			}
		}
		//hier telt die er steeds een bepaalde tijd bij op
		Wachttijd += Time.deltaTime; 
		//wanneer de rechter pijltes toets wordt ingedrukt dan zet die rechts op false
		if (Input.GetKeyDown (KeyCode.RightArrow))
		{
			rechts = false;
		}
		//wanneer de rechter pijltes toets wordt losgelaten dan zet die rechts op true
		if (Input.GetKeyUp (KeyCode.RightArrow)) 
		{
			rechts = true;
		}
	}
}
