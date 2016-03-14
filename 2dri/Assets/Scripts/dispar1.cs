using UnityEngine;
using System.Collections;

public class dispar1 : MonoBehaviour {
	float x, y;

	private Vector3 rot;   
	private bool tocamurs,nomasboladano,bolap1; 
	private CircleCollider2D pc1, pc2; 
	private Collider2D jo;
	private GameObject p1,p2;

	// Use this for initialization
	void Start () {
        rot = transform.rotation.eulerAngles;    
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1500 * Mathf.Cos(rot.z*Mathf.PI/180), 1500 * Mathf.Sin(rot.z*Mathf.PI/180)));
		jo = transform.GetComponent<CircleCollider2D> ();
		p1 = GameObject.FindGameObjectWithTag("player1");
		p2 = GameObject.FindGameObjectWithTag("player2");
		pc1 = p1.GetComponent<CircleCollider2D>();
		pc2 = p2.GetComponent<CircleCollider2D>();
		tocamurs = nomasboladano = false;
      
		if (gameObject.name == "balap1(Clone)") {
			bolap1 = true;
		} else {
			bolap1 = false;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (jo.IsTouchingLayers (LayerMask.GetMask ("murY"))||jo.IsTouchingLayers (LayerMask.GetMask ("murH"))) {
			tocamurs = true;
		}

		if (!tocamurs && !nomasboladano) {
			if(jo.IsTouching(pc1) && !bolap1){
				nomasboladano = true;
				p1.GetComponent<player> ().vida -= 10 * p1.GetComponent<player> ().armadura;
			}
			if(jo.IsTouching(pc2) && bolap1){
				nomasboladano = true;
				p2.GetComponent<player> ().vida -= 10 * p2.GetComponent<player> ().armadura;
			}

		}
	
	}
}
