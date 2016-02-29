using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class player : MonoBehaviour {
    static List<string> upgrades;
    static Dictionary<string,string> armes;
	private GameObject pal,aa;
	private  Vector2 mov;
	private float p1h,p1v,modul, x,y;

	void Start () {
		p1h = p1v = 0; 
		mov = new Vector2 (0, 0);
        armes=new Dictionary<string, string>();
        armes["espasa"] = "espasa";
		armes ["arc"] = "arc";
		armes ["pal"] = "pal";
	}

	void FixedUpdate () {
		
		if(gameObject.CompareTag("player1"))
		{
			p1h = Input.GetAxis ("Horizontal"); 
			p1v = Input.GetAxis ("Vertical");
		}

		if(gameObject.CompareTag("player2"))
		{
			p1h = Input.GetAxis ("player2"); 
			p1v = Input.GetAxis ("player2v");
		}

		mov[0] = p1h; mov[1] = p1v;

		if(Mathf.Sqrt(p1h*p1h+p1v*p1v)>0){
			transform.position = new Vector3 (transform.position.x + p1h/Mathf.Sqrt(p1h*p1h+p1v*p1v)*0.2f, transform.position.y + p1v/Mathf.Sqrt(p1h*p1h+p1v*p1v) * 0.2F,17);	
		}

	}
    
	public string tornaupgrades(string a){
        return armes[a];
	}

	public void activeWeap(string nom){
		pal = Resources.Load (nom, typeof(GameObject)) as GameObject;	
		aa = (Instantiate (pal, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject);
		aa.transform.parent = transform;
		aa.GetComponent<HingeJoint2D> ().connectedBody = gameObject.GetComponent<Rigidbody2D>();
		aa.transform.localScale = new Vector3(0.2f,0.025f,0);
	}

	public void Obrir(bool obre){
		//Aciva i desactiva players
		if(obre)
		{
			gameObject.SetActive (true);
		}
		else{
			gameObject.SetActive (false);
		}
	}
}
