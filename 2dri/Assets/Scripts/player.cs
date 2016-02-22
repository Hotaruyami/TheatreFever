using UnityEngine;
using System.Collections;
public class player : MonoBehaviour {
	private float p1h,p1v, modul, x,y; private  Vector2 mov;
    private string[] upgrades; 
	// Use this for ingetitialization
	void Start () {
		p1h = p1v = 0; mov = new Vector2 (0, 0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(gameObject.CompareTag("player1")){p1h = Input.GetAxis ("Horizontal"); p1v = Input.GetAxis ("Vertical");}
		if(gameObject.CompareTag("player2")){p1h =Input.GetAxis ("player2"); p1v = Input.GetAxis ("player2v");}
		mov[0] = p1h; mov[1] = p1v;

			

		if(Mathf.Sqrt(p1h*p1h+p1v*p1v)>0){
			transform.position = new Vector3 (transform.position.x + p1h/Mathf.Sqrt(p1h*p1h+p1v*p1v)*0.2f, transform.position.y + p1v/Mathf.Sqrt(p1h*p1h+p1v*p1v) * 0.2F,18);
		
		
		}

	}

}
