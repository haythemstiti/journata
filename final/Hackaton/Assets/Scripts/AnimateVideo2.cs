using UnityEngine;
using System.Collections;

public class AnimateVideo2 : MonoBehaviour {

	public GameObject plane;
	bool activated = true;



	void Start()
	{
		Renderer r = plane.GetComponent<Renderer>();
		MovieTexture movie = (MovieTexture)r.material.mainTexture;
		movie.loop = true;
		movie.Play();

		Invoke("displayVideo", Random.Range(3.0f, 5.0f));
	}

	void displayVideo(){
		plane.SetActive (true);
		Invoke("removeVideo", 5f);
	}

	void removeVideo(){
		plane.SetActive (false);
		Invoke("displayVideo", Random.Range(10.0f, 13.0f));
	}
}
