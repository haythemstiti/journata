using UnityEngine;
using System.Collections;

public class AnimateVideo : MonoBehaviour {
	public GameObject plane,plane2;
	bool activated = true;
	bool first = false;
	public worldScript worldScr;

	void Start()
	{
		Renderer r = plane.GetComponent<Renderer>();
		MovieTexture movie = (MovieTexture)r.material.mainTexture;
		movie.loop = true;
		movie.Play();
	}
	void Update()
	{
		if (worldScript.madhloumin > 5 || worldScript.totalEbezzledMoney > 500f && !first) {
			plane2.SetActive (false);
			for (int i = 0; i < 12; i++) {
				worldScript.embezleds[i] = worldScr.deputees[i].GetComponent<deputeeBehaviour>().embezzledMoney;
			}
			plane.SetActive (activated);
			Invoke("activate", 3f);
			first = true;
		}
	}

	void activate(){
		plane.GetComponent<Animation> ().Play();
		Invoke("stop", 1.25f);
	}

	void stop(){
		plane.GetComponent<Animation> ().enabled = false;
		plane.transform.localScale = new Vector3 (2.16f, 1, 1);
		Invoke ("toBilan", 2f);
	}

	void toBilan(){
		Application.LoadLevel ("sceneBilan");
	}
}
