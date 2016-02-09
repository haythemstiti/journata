using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyApparitionScript : MonoBehaviour {

	public GameObject[] texts;
	public AudioClip push, pushOngob;

	public static float total;
	public static int days;


	// Use this for initialization
	void Start () {
		for (int i = 0; i < 12; i++) {
			texts [i].GetComponent<Text> ().text = "" + worldScript.embezleds [i] + "DT";
		}

		total = worldScript.totalEbezzledMoney;
		days = worldScript.numberDays;

		Destroy(GameObject.Find("world"));

		Invoke ("apparition1", 1.1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void apparition1(){
		Invoke ("apparition2", .5f);
		for (int i = 0; i < 4; i++) {
			texts [i].SetActive (true);
		}
		GetComponent<AudioSource> ().PlayOneShot (push);
	}

	void apparition2(){
		Invoke ("apparition3", .7f);
		for (int i = 4; i < 8; i++) {
			texts [i].SetActive (true);
		}
		GetComponent<AudioSource> ().PlayOneShot (push);
	}

	void apparition3(){
		for (int i = 8; i < 12; i++) {
			texts [i].SetActive (true);
		}
		GetComponent<AudioSource> ().PlayOneShot (pushOngob);
	}
}
