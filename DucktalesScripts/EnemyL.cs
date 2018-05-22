using UnityEngine;
using System.Collections;

public class EnemyL : MonoBehaviour {

	public float FPS;
	public Texture[] frames;
	private float secWachttijd;
	private int huidigFrame;
	public bool herhaal;
	public bool links;
	public bool links1;

	void Start () 
	{
		huidigFrame = 0;
		secWachttijd = 1 /FPS;
		links = true;
		links1 = true;
	}
	void Update()

	{
		//wanneer de boolean links true is start die de animatie en zet die de variable true op false
		if (links == true)
		{
			StartCoroutine (AnimatieRoutine ());
			links = false;
		}
	}
	IEnumerator AnimatieRoutine()
	{
		//hier maak ik de boolean stoppen aan en zet hem op false
		bool stoppen = false;

			if (huidigFrame >= frames.Length) {
				if (!herhaal) {
					stoppen = true;
				} else {
					huidigFrame = 0;
				}
			}

			yield return new WaitForSeconds (secWachttijd);

			GetComponent<Renderer> ().material.mainTexture = frames [huidigFrame];
			huidigFrame++;

			if (!stoppen) {
				
			if (links1 == true) 
			{
				StartCoroutine (AnimatieRoutine ());
			}
			}

	}
	void OnTriggerEnter(Collider other)
	{
		//als die de linker muur aanraakt dan gaat links op true
		if (other.gameObject.tag == "muurLinks") 
		{
			links = true;
			links1 = true;

		}
		//als die de rechter muur raakt zet die links op false
		if (other.gameObject.tag == "muurRechts") 
		{
			links = false;
			links1 = false;
		}
	}
}
