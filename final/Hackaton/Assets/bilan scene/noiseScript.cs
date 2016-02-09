using UnityEngine;
using System.Collections;

public class noiseScript : MonoBehaviour {

	// Use this for initialization
	public Sprite[] sprites;
	bool inFirstSprite =true;
	void Start () {
		InvokeRepeating ("MakeNoise", 0f, 0.1f);
		Invoke ("Disappear", 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (inFirstSprite) {
			this.GetComponent<SpriteRenderer> ().sprite = sprites [1];
			inFirstSprite = false;
		}
		else 
		{
			this.GetComponent<SpriteRenderer> ().sprite = sprites [0];
			inFirstSprite = true;
		}
	}

	void MakeNoise()
	{
		this.transform.localScale = new Vector3(-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
	}

	void Disappear()
	{
		GameObject.Destroy (this.gameObject);
	}
}
