using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class bombolla : MonoBehaviour {
	private GameObject p1, p2, b1, b2,bc1,bc2;


	// Use this for initialization
	void Start () {
		p1 = GameObject.FindGameObjectWithTag("player1");
		p2 = GameObject.FindGameObjectWithTag("player2");
		b1 = GameObject.FindGameObjectWithTag("b1");
		b2 = GameObject.FindGameObjectWithTag("b2");
		bc1 = b1.transform.Find("walls").gameObject;
		bc2 = b2.transform.Find("walls").gameObject;
	}

	// Update is called once per frame
	void FixedUpdate () { 
		if (p1.transform.position.x >= b1.transform.position.x - 1 && p1.transform.position.x <= b1.transform.position.x + 1 && p1.transform.position.y >= b1.transform.position.y - 1 && p1.transform.position.y <= b1.transform.position.y + 1) {
			bc1.SetActive (true);


		} 
		if (p2.transform.position.x >= b2.transform.position.x - 1 && p2.transform.position.x <= b2.transform.position.x + 1 && p2.transform.position.y >= b2.transform.position.y - 1 && p2.transform.position.y <= b2.transform.position.y + 1) {
			bc2.SetActive (true);

		} 
			
	}
}
