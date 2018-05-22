using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Klik : MonoBehaviour {

	private Ray ray;
	private RaycastHit raycastHit;

	void Start () {
	
	}
	

	void Update () 
	{
		
		//Dit is voor de startscherm, creditsscherm, instructiescherm, gameoverscherm en eindscherm
		if (Input.GetMouseButtonDown (0)) 
		{
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out raycastHit)) 
			{
				if (raycastHit.transform.name == "Hoofdscherm") 
				{
					SceneManager.LoadScene ("StartScherm"); 
				}
				if (raycastHit.transform.name == "Start") 
				{
					SceneManager.LoadScene ("Game"); 
				}
				if (raycastHit.transform.name == "TerugMenu") 
				{
					SceneManager.LoadScene ("StartScherm"); 
				}
				if (raycastHit.transform.name == "Instructies2") 
				{
					SceneManager.LoadScene ("Instructies"); 
				}
				if (raycastHit.transform.name == "Credits") 
				{
					SceneManager.LoadScene ("Credits"); 

				}
			}
		}
	
	}
}
