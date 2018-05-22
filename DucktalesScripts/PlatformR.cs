using UnityEngine;
using System.Collections;

public class PlatformR : MonoBehaviour {

	public float FPS;
	public bool rechts;
	public bool rechts1;

	void Start () 
	{
		rechts = false;
		rechts1 = false;
	}

	void Update()
	{
		if (rechts == true)
		{
			
			rechts = false;
		}
	}



	void OnTriggerEnter(Collider other)
	{
		//als die de rechter muur aanraakt dan gaat rects en rechts1 true
		if (other.gameObject.tag == "MuurRechts") 
		{
			rechts = true;
			rechts1 = true;
		}
		//als die de linker muur aanraakt dan gaat rects en rechts1 false
		if (other.gameObject.tag == "MuurLinks") 
		{
			rechts = false;
			rechts1 = false;
		}
	}
}