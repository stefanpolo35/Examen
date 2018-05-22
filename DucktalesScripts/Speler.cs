using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Speler : MonoBehaviour {
	//hier maak ik variabele aan
	    public GUISkin tekstSkin;
		public static int score;
		float levens;
		float Eierteller;
		float vijandlevens;
		public float snelheid;
		Vector3 positie;
	    public Rigidbody rb;
		Vector3 beginPositie;
		GameObject[] bijen; 
		public GameObject tekstbox;
		public GameObject tekstbox2;
		public GameObject tekstbox3;
		public GameObject tekstbox4;
		public GameObject tekstbox5;
		public GameObject tekstbox6;
		float xSpeed;
		
	void Start () 
		{
		//hier stel ik de begin levens in, de begin positie, xSpeed en zeg ik dat die de tag bee moet vinden
		levens = 3;
		vijandlevens = 6;
		Eierteller = 0;
		score = 0;
		beginPositie = new Vector3 ( -4.142f, -1.66f, 0);
		positie = new Vector3 ( -4.142f, -1.66f, 0);
		rb = GetComponent<Rigidbody> ();
		bijen = GameObject.FindGameObjectsWithTag ("bee");
		xSpeed = 0.7f;
		}
	void OnGUI() 
	{
		//dit zijn de teksten die in beeld staan
		GUI.skin = tekstSkin;
		GUI.color = Color.yellow;
		GUI.Label (new Rect (20, 40, 300, 100), "$ " + score);
		GUI.Label (new Rect (20, 65, 300, 100), "Levens: " + levens);
	}

		void Update ()
	{
		//hier laat ik hem lopen op de horizontale as	
		transform.Translate (Input.GetAxis ("hor") * snelheid * Time.deltaTime, 0, 0);
		//als de levens 0 zijn dan ga je naar het gameover scherm
		if (levens == 0) 
		{
			SceneManager.LoadScene ("GameOver");
			score = 0;
		}

	}

	void OnTriggerEnter(Collider other)
	{
		

			
		//als je de munt aanraakt dan detroyed die de kist en krijg je 10 score
		if (other.gameObject.tag == "munt") 
		{
			Destroy (other.gameObject);
			score += 10;
		}
		//als je de boxcollider op de enemy zijn hoofd raakt dann wordt die gedestroyd
		if (other.gameObject.tag == "Enemy") 
		{
			Destroy (other.gameObject);

		}
			//als je de boxcollider op de enemy2 zijn hoofd raakt dann wordt die gedestroyd
			if (other.gameObject.tag == "Enemy2") 
			{
				Destroy (other.gameObject);

			}
		//als je de chest aanraakt dan detroyed die de kist en krijg je 100 score
		if (other.gameObject.tag == "Chest") 
		{
			Destroy (other.gameObject);
			score += 100;
		}
		//als je in het lavasrpingt raak je dit blok aan en word je terug gezet naar de beginpositie en gaat er een leven af
		if (other.gameObject.tag == "lavadood") 
		{
			transform.position = beginPositie;
			levens -= 1;
		}
		//als je in het lavasrpingt raak je dit blok aan en word je terug gezet naar de beginpositie en gaat er een leven af
		if (other.gameObject.tag == "lavadood2") 
		{
			transform.position = new Vector2(12.99f, -1.68f);
			levens -= 1;
		}
		// als je kwik(groen)aanraakt dan komt de 1e tekst in beeld
		if (other.gameObject.tag == "Kwik") 
		{
			tekstbox.transform.position = new Vector3 (-2.433f, -1.219f, 1);

		}
		//dit is voor de kwik op het einde
		if (other.gameObject.tag == "Kwik2") 
		{
			tekstbox4.transform.position = new Vector3 (41.42f, -1.188f, 1);
			tekstbox5.transform.position = new Vector3 (41.42f, -4, 1);
			tekstbox6.transform.position = new Vector3 (41.42f, -4, 1);

		}
		// als je kwak(rood) aanraakt dan komt de 2e tekst in beeld
		if (other.gameObject.tag == "Kwak") 
		{
			tekstbox2.transform.position = new Vector3 (14.61f, -1.27f, 1);

		}
		//dit is voor de kwak op het einde
		if (other.gameObject.tag == "Kwak2") 
		{
			tekstbox5.transform.position = new Vector3 (42.336f, -1.134f, 1);
			tekstbox4.transform.position = new Vector3 (41.42f, -4, 1);
			tekstbox6.transform.position = new Vector3 (41.42f, -4, 1);

		}
		// als je kwek(rood) aanraakt dan komt de 2e tekst in beeld
		if (other.gameObject.tag == "Kwek") 
		{
			tekstbox3.transform.position = new Vector3 (34.19f, -1.31f, 1);

		}
		//dit is voor de kwek op het einde
		if (other.gameObject.tag == "Kwek2") 
		{
			tekstbox6.transform.position = new Vector3 (43.263f, -1.134f, 1);
			tekstbox4.transform.position = new Vector3 (41.42f, -4, 1);
			tekstbox5.transform.position = new Vector3 (41.42f, -4, 1);

		}
		//als je de bijen aanraakt dan zet die je terug naar de beginpositie en haalt die er een leven vanaf
		if (other.gameObject.tag == "bee") {
				transform.position = new Vector2(12.99f, -1.68f);
			levens -= 1;
		
			// hier destroyd die alle bijen totdat variable i op 0 staat
			for (var i = 0; i < bijen.Length; i++) {
				Destroy (bijen [i]);
			}
		}
		//als je de spikes aanraakt dan zet die je terug naar de beginpostite en haalt die er een leven vanaf
		if (other.gameObject.tag == "Spikes") 
		{
				transform.position =  new Vector2(12.99f, -1.68f);
			levens -= 1;
		}

		//als je de diamand aanraakt dan vernietigd die de diamand en krijg je er 1000 punten bij
		if (other.gameObject.tag == "diamand") 
		{
			Destroy (other.gameObject);
			score += 1000;
		}
		if (other.gameObject.tag == "GoudEi") 
			{
				Destroy (other.gameObject);
				SceneManager.LoadScene ("Eindscherm");
			}
		//als die het ei aanraakt dan destroyed die het ei en doe die de eierteller +1
		if (other.gameObject.tag == "RegenboogEi") 
			{
				Destroy (other.gameObject);
				Eierteller += 1;
			}
		//als die het ei aanraakt dan destroyed die het ei en doe die de eierteller +1
		if (other.gameObject.tag == "RoodEi") 
			{
				Destroy (other.gameObject);
				Eierteller += 1;
			}
		//als die het ei aanraakt dan destroyed die het ei en doe die de eierteller +1
		if (other.gameObject.tag == "BlauwEi") 
			{
				Destroy (other.gameObject);
				Eierteller += 1;
			}
		//als die het ei aanraakt dan destroyed die het ei en doe die de eierteller +1
		if (other.gameObject.tag == "ZwartEi") 
			{
				Destroy (other.gameObject);
				Eierteller += 1;
			}
		//wanneer de teller op 4 staat dan wordt de speler naar de niewue positie geteleporteert
		if (Eierteller == 4) 
			{
				transform.position = new Vector2 (73.92f, 1.72f);
			}
			
		}


	


	void OnCollisionEnter (Collision Dood)
	{
		
		//wanneer de speler de collider(is trigger) aanraakt van de eindbaas dan doet die er een leven vanaf 
	
		if (Dood.gameObject.tag == "Enemy") 
		{
			levens -= 1;
			transform.position = beginPositie;
		}
		//voor de checkpoint
		if (Dood.gameObject.tag == "Enemy2") 
		{
			levens -= 1;
			transform.position = new Vector2(12.99f, -1.68f);
		}

		if (Dood.gameObject.tag == "plant") 
		{
			levens -= 1;
			transform.position = beginPositie;
		}
		//voor de checkpoint
		if (Dood.gameObject.tag == "Plant") 
		{
			levens -= 1;
			transform.position = new Vector2(12.99f, -1.68f);
		}
	}

	void OnCollisionStay ()
	{
		//dit is voor het springen
		if (Input.GetButtonDown ("Jump")) 
		{
			rb.velocity = new Vector3 (0, 4.5f, 0);
		}
	}

}
