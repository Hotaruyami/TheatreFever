using UnityEngine;
using System.Collections;

public class nocaiga : MonoBehaviour {

	public bool e;
	public GameObject p1,p2;

	private GameObject bola;
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
				bola = Resources.Load ("bola", typeof(GameObject)) as GameObject;	
				posBull = new Vector3 (0, 4, 18);
				Instantiate (bola, posBull, Quaternion.identity);
				bola = GameObject.FindGameObjectWithTag("bola");
				e = true;
			}
		}
		//bola.transform.position = new Vector3 (p1.transform.position.x-0.5f, p1.transform.position.y, p1.transform.position.z);
//		if (Input.GetKeyDown (KeyCode.Keypad0))
//		{
//
//		}

	}

}
