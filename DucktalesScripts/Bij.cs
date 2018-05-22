using UnityEngine;
using System.Collections;

public class Bij : MonoBehaviour {
	float xSpeed;
	public GameObject dagobert;
	// Use this for initialization
	void Start () 
	{
		xSpeed = 0f;
	}


	void Update () 
	{
		//hier laat ik ze automatisch een kant op vliegen
		transform.Translate (xSpeed * Time.deltaTime, 0, 0);
		//wanneer de speler verder is de 12 op de x as dan beginnen de bijen met vliegen
		if (dagobert.transform.position.x > 12) 
		{
			xSpeed = 0.7f;
		}
	}

}
