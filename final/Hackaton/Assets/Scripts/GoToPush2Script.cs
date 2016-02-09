using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoToPush2Script : MonoBehaviour {

	public GameObject canvas;
	public Text daysText, moneyText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		GameObject.Find ("nouwebBilan").SetActive(false);
		canvas.SetActive (true);
		daysText.text = "" + MoneyApparitionScript.days + " nhar";
		moneyText.text = "" + MoneyApparitionScript.total + "DT\n" 
			+ (MoneyApparitionScript.total/MoneyApparitionScript.days*30) + "DT / mois\n"
			+ (MoneyApparitionScript.total/MoneyApparitionScript.days*365) + "DT / an";
		gameObject.SetActive (false);
	}
}
