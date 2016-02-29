using UnityEngine;
using System.Collections;

public class nocaiga : MonoBehaviour {

	public bool e;
	public GameObject p1,p2;

	private GameObject rombo;
	private Vector3 posBull;


	// Use this for initialization
	void Start () {
		e = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftShift))
		{
			if (!e) {
				rombo = Resources.Load ("rombo", typeof(GameObject)) as GameObject;	
				posBull = new Vector3 (0, 4, 18);
				Instantiate (rombo, posBull, Quaternion.identity);
				rombo = GameObject.FindGameObjectWithTag ("rombo");
				e = true;
			} else {
				
			}
		}

//		if (Input.GetKeyDown (KeyCode.Keypad0))
//		{
//
//		}

	}

}
