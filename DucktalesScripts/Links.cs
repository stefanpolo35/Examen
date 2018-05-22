using UnityEngine;
using System.Collections;

public class Links : MonoBehaviour {

	public float FPS1;
	public Texture[] frames1;
	private float secWachttijd1;
	float Wachttijd1;
	private int huidigFrame1;
	public bool herhaal1;
	public bool links;
	bool stoppen1 = false;

	void Start () 
	{
		StartCoroutine (AnimatieRoutine1 ());
		huidigFrame1 = 0;
		secWachttijd1 = 1 /FPS1;
		links = false;
	}

	IEnumerator AnimatieRoutine1()
	{
		if (huidigFrame1 >= frames1.Length) 
		{
			if (!herhaal1) 
			{
				stoppen1 = true;
			} 
			else 
			{
				huidigFrame1 = 0;
			}
		}

		yield return new WaitForSeconds (secWachttijd1);

		GetComponent<Renderer>().material.mainTexture = frames1 [huidigFrame1];
		huidigFrame1++;



	}

	void Update ()
	{
		if (links == false) {

			if (Wachttijd1 > 0.1f) 
			{
				if (!stoppen1) {
					StartCoroutine (AnimatieRoutine1 ());
				}
				Wachttijd1 = 0;
			}
		}

		Wachttijd1 += Time.deltaTime; 

		if (Input.GetKeyDown (KeyCode.LeftArrow))
		{
			links = false;
		}

		if (Input.GetKeyUp (KeyCode.LeftArrow)) 
		{
			links = true;
		}
	}
}

