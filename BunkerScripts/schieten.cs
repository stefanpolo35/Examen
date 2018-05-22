using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class schieten : MonoBehaviour 
{
	Animator animatie;
	public Animation anim;

	public Camera fpsCamera;
    public ParticleSystem vuur;
    public GameObject kogel;
	public GameObject impact;

	public float range = 100f;
	float firerate = 0;
	float impactForce = 300f;
	float reloadTijd = 0;
	float folume;

	int kogels = 30;

	public Text KOGELS;

	private AudioSource soundeffect;
	public AudioClip shootsound;
	public AudioClip reload;


	// Use this for initialization
	void Start () 
	{
		animatie = GetComponent <Animator> ();
		anim = GetComponent<Animation> ();
		soundeffect = GetComponent<AudioSource>();

		reloadTijd = 0;
	}

	// Update is called once per frame
	void Update () 
	{
		firerate -= Time.deltaTime;
		reloadTijd -= Time.deltaTime;

	//	print (reloadTijd);
	//	print (kogels);

		Texten();
		Animatie ();

		if (Input.GetButton ("Fire1") && firerate < 0 && kogels > 0)
		{
            Schieten ();
		}

		if (reloadTijd <= -2 && kogels == 0 || Input.GetKeyDown(KeyCode.R)) 
		{
			reloadTijd = 5.6f;
			animatie.SetTrigger ("Reloaden");
			soundeffect.PlayOneShot (reload, 1);
		}

		if (reloadTijd <= 0 && reloadTijd >=  -0.1f) 
			{
				kogels = 30;
			}
	}

	void Texten()
	{
		KOGELS.text = "" + kogels;
	}

	void Animatie()
	{
		if (Input.GetMouseButton(0) && kogels > 0)
		{
            vuur.Play();
            animatie.SetBool ("Schieten", true);
		}

		else
		{
            vuur.Stop();
            animatie.SetBool ("Schieten", false);
		}
	}

	void Schieten()
	{
        RaycastHit hit;
		firerate = 0.2f;
		kogels--;

		folume = Random.Range (0.5f, 1.0f);

		soundeffect.PlayOneShot (shootsound, folume);


		if(Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
			if (hit.rigidbody != null) 
			{
				hit.rigidbody.AddForce (-hit.normal * impactForce);

				if (hit.transform.tag == "Vijand") 
				{
					Destroy (hit.transform.gameObject);
				}
			}

			GameObject flar = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
			Destroy (flar, 1);

        }
	}
}
