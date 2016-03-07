using UnityEngine;
using System.Collections;

public class arc : MonoBehaviour {

	private GameObject p1,p2;
	private GameObject bala;
	private Vector3 posBull;

	void Start () {
		p1 = GameObject.FindGameObjectWithTag("player1");
		p2 = GameObject.FindGameObjectWithTag("player2");
	}
	

	void FixedUpdate () {
		//Pretenia fer un  as GameObject).transform.parent = p1.transform.FindChild("arc(Clone)");, pro aleshires les bales es mouen amb el player
		//I per alguna raó, es disparen dues bales cada cop xD
		if (Input.GetKeyDown (KeyCode.LeftShift)) //Player 2 dispara
		{
			bala = Resources.Load ("bala", typeof(GameObject)) as GameObject;	
			posBull = new Vector3 (p2.transform.position.x,p2.transform.position.y+1,p2.transform.position.z);
			Instantiate (bala, posBull, Quaternion.identity);
		}
//		if (Input.GetKeyDown (KeyCode.M)) //Player 1 dispara
//		{
//			bala = Resources.Load ("bala", typeof(GameObject)) as GameObject;	
//			posBull = new Vector3 (p1.transform.position.x,p1.transform.position.y+1,p1.transform.position.z);
//			Instantiate (bala, posBull, Quaternion.identity);
//		} 
	
	}
}
