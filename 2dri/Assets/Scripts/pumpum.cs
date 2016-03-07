using UnityEngine;
using System.Collections;

public class pumpum : MonoBehaviour {
	public cargar Anarsesala;

	private GameObject p1,p2;
	private Collider2D pumpu;
	private CircleCollider2D p1box;
	private player loco,loco2;
	private bool afegir;

	void Start () {
		afegir = false;
		p1 = GameObject.FindGameObjectWithTag("player1");
		p2 = GameObject.FindGameObjectWithTag("player2");
		loco = p1.GetComponent<player>(); //Script p1
		loco2 = p2.GetComponent<player>();
		p1box = p1.GetComponent<CircleCollider2D>(); //CC del player
		pumpu = GetComponent<BoxCollider2D>(); //Collider de la sala
	}

	void FixedUpdate () { 
		if (!afegir) 
		{ 
			if (p1box.IsTouching(pumpu))
			{	
				//Activa arma  
				loco.activeWeap ("arc");
				loco2.activeWeap ("arc");
				afegir = true;
			} 
		}


	}
}