using UnityEngine;
using System.Collections;

public class PlatformL : MonoBehaviour {

	float xSpeed;
	public bool links;
	public bool links1;

	void Start () 
	{
		links = true;
		links1 = true;
		xSpeed = 0.7f;
	}
	void Update()

	{
		
		if (links == true)
		{
			transform.Translate (xSpeed * Time.deltaTime, 0, 0);
		}

		if (links == false)
		{
			transform.Translate (-xSpeed * Time.deltaTime, 0, 0);
		}
	}



	void OnTriggerEnter(Collider other)
	{
		//als die de linker muur aanraakt dan gaat links false
		if (other.gameObject.tag == "MuurLinks") 
		{
			links = false;



		}
		//als die de rechter muur aanraakt dan gaat links true
		if (other.gameObject.tag == "MuurRechts") 
		{
			links = true;
		}
	}
}
