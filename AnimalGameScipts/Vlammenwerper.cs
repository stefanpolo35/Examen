using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vlammenwerper : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.F)) 
		{
			GetComponent<Animator>().SetBool("Flame", true);
		}
		if (Input.GetKeyUp(KeyCode.F)) 
		{
			GetComponent<Animator>().SetBool("Flame", false);
		}
	}
}
