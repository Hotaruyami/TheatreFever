using UnityEngine;
using System.Collections;

public class pumpum : MonoBehaviour {
	public cargar Anarsesala;

	private GameObject p1,p2;
	private Collider2D pumpu;
	private CircleCollider2D p1box;
	private player loco,loco2;
	private bool afegir,fin,nomas;
	private Vector3 B1,B2;

	public GameObject bubbleW, bubbleL;
	public bombolla bubledins1, bubledins2;
	public upgrade upgr;

	void Start () {
		afegir = fin = nomas = false;
		p1 = GameObject.FindGameObjectWithTag("player1");
		p2 = GameObject.FindGameObjectWithTag("player2");
		loco = p1.GetComponent<player>(); //Script p1
		loco2 = p2.GetComponent<player>();
		p1box = p1.GetComponent<CircleCollider2D>(); //CC del player
		pumpu = GetComponent<BoxCollider2D>(); //Collider de la sala

	}

	void FixedUpdate () { 
		if (p1box.IsTouching (pumpu)) {	
			if (!afegir) { 
				//Activa arma  
				loco.activeWeap ("arc");
				loco2.activeWeap ("arc");
				afegir = true;
			
			}
			if (!fin) {
				if (loco.vida <= 0 || loco2.vida <= 0) {
					final ();
				}
		}
			if ((bubledins1.dins1 () && bubledins2.dins2 ()) && !nomas) {
				// canvi de sala al script cargar
				Anarsesala.canviSala ();
				loco.desactivarWeap ("arc");
				loco2.desactivarWeap ("arc");
				loco.vida = 100; //Reset puntuacions
				p1.transform.localRotation = new Quaternion (0, 0, 0, 0); //Posem la rotacio del player a 0
				p2.transform.localRotation = new Quaternion (0, 0, 0, 0);
				upgr.comensa (true);//fica upgrades als players
				nomas = true;

			}
		}	

	}

	void final(){
		fin = true;
		B1 = new Vector3 (-7,-3,18); B2 = new Vector3 (7,-3,18);
		Instantiate (bubbleW,B2,Quaternion.identity);//Fa apareixer les bombolles
		Instantiate (bubbleL,B1,Quaternion.identity);
		Anarsesala.AsignSalaDelete(pumpu);
	}

}