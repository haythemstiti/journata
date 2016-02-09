using UnityEngine;
using System.Collections;

public class deputeeBehaviour : MonoBehaviour {

	// Use this for initialization
	public float speed = 15f;
	public bool wasAbsent = false;
	public bool isDeparted = false;
	public Vector2 targetSpot;
	public GameObject departureSpot;
	public GameObject seatSpot;
	public GameObject impact;
	public GameObject iClone;
	public int salary = 2300;
	public int embezzledMoney = 0;
	public bool embezzlable = false;
    public bool busted = false;

	public AudioClip owMaleAudio;
	public AudioClip owFemaleAudio;
	public AudioClip punchAudio;
	public AudioClip ongobAudio1;
	public AudioClip ongobAudio2;

	void Start () {
		targetSpot = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = Vector2.MoveTowards (this.transform.position, targetSpot, speed * Time.deltaTime);
	}

	public void Move()
	{
		if (targetSpot == (Vector2)departureSpot.transform.position) {
			targetSpot = seatSpot.transform.position;
		}
		else 
		{
			targetSpot = departureSpot.transform.position;
		}
	}
	 void OnMouseDown()
	{
        Debug.Log("clicked");
		if (embezzlable) {
            busted = true;
			iClone = GameObject.Instantiate (impact,transform.position,Quaternion.identity) as GameObject;
			GetComponent<AudioSource> ().Play ();
			Invoke ("destroyImpact", 0.2f);
			GetComponentInChildren<AnimateMouth> ().invokeAnimateHit ();

			int random = Random.Range (0, 5);
			if (random == 0) {
				GetComponent<AudioSource> ().PlayOneShot (punchAudio);
			}
			else{
				int random2 = Random.Range (0, 1);
				if (random2 == 0) {
					GetComponent<AudioSource> ().PlayOneShot(ongobAudio1);
				}
				else{
					GetComponent<AudioSource> ().PlayOneShot(ongobAudio2);
				}
			}
		}
        else
        {
            worldScript.madhloumin++;
			if(name == "Bochra" || name == "Sabrine" || name == "Mehrzya")
				GetComponent<AudioSource> ().PlayOneShot(owFemaleAudio);
			else
				GetComponent<AudioSource> ().PlayOneShot(owMaleAudio);
        }
	}

	void destroyImpact(){
		Destroy (iClone);
	}
}
