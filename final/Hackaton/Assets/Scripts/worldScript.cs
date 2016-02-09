using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class worldScript : MonoBehaviour {

	// Use this for initialization
	public float timeToEndDay = 10f;
	public float defaultTimeToEndDay = 5f;
	public bool dayEnded = false;

	public float timeToBeginDay = 0f;
	public float defaultTimeToBeginDay = 2f;
	public bool dayBegun = true;

	public List<GameObject> deputees;
	static public List<GameObject> deputeesStatic;
	public int numberOfAbsents = 0;

	public static float totalEbezzledMoney = 0;

    public static int madhloumin = 0;

	public static int[] embezleds = new int[12];
	public static int numberDays = 0;

	void Start () {
		totalEbezzledMoney = 0;
		madhloumin = 0;
		numberDays = 0;
		GameObject.DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        
		if (dayBegun) {
			
			AudioSource aSource = GetComponent<AudioSource> ();
			if (!aSource.isPlaying) {
				aSource.Play ();
			}


			if (timeToEndDay > 0) {
				timeToEndDay -= Time.deltaTime;
			}
			else
			{
				numberDays++;
				foreach (GameObject deputee in deputees) {
                    if (deputee.GetComponentInChildren<deputeeBehaviour>().embezzlable == true &&
                        deputee.GetComponentInChildren<deputeeBehaviour>().busted == false)
                    {

                        deputee.GetComponentInChildren<deputeeBehaviour>().embezzledMoney = deputee.GetComponentInChildren<deputeeBehaviour>().salary / 30;
                        totalEbezzledMoney += deputee.GetComponentInChildren<deputeeBehaviour>().embezzledMoney;
                        Debug.Log("Total bazzel " + totalEbezzledMoney);
                        deputee.GetComponentInChildren<deputeeBehaviour>().embezzlable = false;
                 //       Debug.Log("Embezzable true day begun " + deputee.name);
                    }
                    if(deputee.GetComponentInChildren<deputeeBehaviour>().embezzlable == true &&
                        deputee.GetComponentInChildren<deputeeBehaviour>().busted == true)
                    {  
                        deputee.GetComponentInChildren<deputeeBehaviour>().busted = false;
                    }
                    if (deputee.GetComponentInChildren<deputeeBehaviour> ().wasAbsent == false) {
						deputee.GetComponentInChildren<deputeeBehaviour>().Move ();
					} 
					else {
                        deputee.GetComponentInChildren<deputeeBehaviour>().embezzlable = true;
                        deputee.GetComponentInChildren<deputeeBehaviour> ().wasAbsent = false;
                        



                    }
                   
                //    Debug.Log("day begun " + deputee.name);
                  //  deputee.GetComponentInChildren<deputeeBehaviour>().embezzlable = true;




                }
				dayBegun = false;
				dayEnded = true;
				timeToEndDay = defaultTimeToEndDay;
                Debug.Log("Madhloumin: " + madhloumin);
            }
		}

		else if (dayEnded) {
			if (timeToBeginDay > 0 ) {
				timeToBeginDay -= Time.deltaTime;
			}
			else
			{
				foreach (GameObject deputee in deputees) {
					if (Random.Range (0f, 1f) > 0.5f && numberOfAbsents > 0) {
						numberOfAbsents--;
                //        Debug.Log("Embezzable true day end "+deputee.name);
						deputee.GetComponentInChildren<deputeeBehaviour> ().wasAbsent = true;
					} 
					else
					{
						
						deputee.GetComponentInChildren<deputeeBehaviour>().Move ();

					}


				}
				dayBegun = true;
				dayEnded = false;
				numberOfAbsents = Random.Range (0,5);
				timeToBeginDay = defaultTimeToBeginDay;
			}	
		}



	}

}
