using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class bola : MonoBehaviour {
	private Collider2D g, edc, esc, pelotavasca;
	private Rigidbody2D r,p1R,p2R;
	private GameObject p1, p2,pal;
	private bool turn,fin,afegir,nomas;
	private Color colorp1,colorp2;
	private Vector3 B1,B2;
	private int pun1,pun2;
	private Text puntp1, puntp2;
	private player loco,loco2;
	private CircleCollider2D p1box;

    public bombolla bubledins1, bubledins2;
	public GameObject es, ed, bubbleW, bubbleL;
	public SpriteRenderer color;
    public cargar Anarsesala;
   
	void Start () {
        afegir = nomas = false;
		pun1 = pun2 = 0;
		p1 = GameObject.FindGameObjectWithTag("player1");
		p2 = GameObject.FindGameObjectWithTag("player2");
		g = GetComponent <CircleCollider2D> ();
		p1box = p1.GetComponent<CircleCollider2D>();
		r = GetComponent <Rigidbody2D>();
		edc = ed.GetComponent <BoxCollider2D> ();     
		esc = es.GetComponent <BoxCollider2D> ();
		fin = turn = false; //turn false = tira player1
        colorp1 = p1.GetComponent<SpriteRenderer>().color;
		colorp2 = p2.GetComponent<SpriteRenderer>().color;
		bubbleW.GetComponent<SpriteRenderer>().color = colorp1;
		bubbleL.GetComponent<SpriteRenderer>().color = colorp2;
		puntp1 = GameObject.Find("pplayer1").GetComponent<Text>();
		puntp2 = GameObject.Find("pplayer2").GetComponent<Text>();
		puntp1.text = "P1: " + pun1;
		puntp2.text = "P2: " + pun2;
		loco = p1.GetComponent<player>();
		loco2 = p2.GetComponent<player>();
       	pelotavasca = GameObject.FindGameObjectWithTag("sala1m").GetComponent<BoxCollider2D>();
	}

	void FixedUpdate () {

		if (!afegir) {
			if (p1box.IsTouching(pelotavasca))
			{
				//Activa arma  
				loco.activeWeap ("pal");
				loco2.activeWeap ("pal");
				afegir = true;
			}    
        }

		if (!fin) {
			if (!turn) {// turn player 1
				color.color = colorp1;
			} else { // Turn player 2
                color.color = colorp2;
			}
		
			if (g.IsTouchingLayers (LayerMask.GetMask ("murH"))) {
				if (pun1 < 1 && pun2 < 1) {
					r.velocity = new Vector2 (-7 * Mathf.Sign (r.velocity.x), r.velocity.y);

					if (g.IsTouching (esc)) { // mur esquerra
						if (turn) { //Turn p2
							pun1++;
							puntp1.text = "P1: " + pun1;
							if(pun1 >= 1){
								final ();
							}
						} else { // Turn p1
							pun2++;
							puntp2.text = "P2: " + pun2;
							if(pun2 >= 1){
								final ();
							}
						}
					}
					if (g.IsTouching (edc)) { // mur dret
						if (!turn) {
							turn = true;
						} else if (turn) {
							turn = false;
						}
					}
				}
			} //FIN MUR H

			if (g.IsTouchingLayers (LayerMask.GetMask ("murY"))) {
				r.velocity = new Vector2 ((r.velocity.x), -7 * Mathf.Sign (r.velocity.y));
			} //FIN MUR Y
		}
		if (bubledins1.dins1() && bubledins2.dins2()) {
			g.isTrigger = true;
			gameObject.SetActive (false);
			if (!nomas) { // canvi de sala al script cargar
				Anarsesala.canviSala ();
				nomas = true;
			}

		}    
       
	} //FIN !FIN
	void final(){
		fin = true;
		color.color = new Color (1f, 1f, 1f, 1f);
		B1 = new Vector3 (-7,-3,18);
		B2 = new Vector3 (7,-3,18);
		Instantiate (bubbleW,B2,Quaternion.identity);//Fa apareixer les bombolles
		Instantiate (bubbleL,B1,Quaternion.identity);

		// Fer un destroy de la bola, amb una animació? (explosió)
	}
}
