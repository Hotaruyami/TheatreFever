using UnityEngine;
using System.Collections;

public class pumpum : MonoBehaviour {
	public GameObject p1,p2;
	private GameObject rombo;
	private Vector3 posBull;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.LeftShift))
		{
				rombo = Resources.Load ("rombo", typeof(GameObject)) as GameObject;	
				posBull = new Vector3 (p1.transform.position.x,p1.transform.position.y,p1.transform.position.z);
				Instantiate (rombo, posBull, Quaternion.identity);
				rombo = GameObject.FindGameObjectWithTag ("rombo");
				
			} 
		}
	
	}
