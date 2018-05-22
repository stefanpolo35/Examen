using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ScoreEind : MonoBehaviour {


	public GUISkin tekstSkin;
	public static int score;
	void Start () 
	{	
		
	}

	// Update is called once per frame
	void Update ()
	{
		//hier vraag ik de variabele score op uit het script Speler
		score = Speler.score;
	}
	void OnGUI() 
	{

		//dit zijn de teksten die in beeld staan
		GUI.skin = tekstSkin;
		GUI.color = Color.yellow;
		GUI.Label (new Rect (300f, 600f, 700, 100), "Jouw eind score is: $" + score);

	}

}
