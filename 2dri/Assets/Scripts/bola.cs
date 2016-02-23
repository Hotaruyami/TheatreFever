using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bola : MonoBehaviour {
	private Collider2D g, edc, esc;
	private Rigidbody2D r;
	private GameObject p1, p2;
	private bool turn,fin,toc;
	private Color colorp1,colorp2;
	private int punts1, punts2;

	public GameObject es, ed,bubbleW,bubbleL;
	public SpriteRenderer color;
	public Text puntp1,puntp2;

    
	// Use this for initialization
	void Start () {
		punts1 = punts2 = 0;
		g = GetComponent <CircleCollider2D> ();
		r = GetComponent <Rigidbody2D>();
		edc = ed.GetComponent <BoxCollider2D> ();
		esc = es.GetComponent <BoxCollider2D> ();
		toc = fin = turn = false; //turn false= tira player1
        p1 = GameObject.FindGameObjectWithTag("player1");
        p2 = GameObject.FindGameObjectWithTag("player2");
        colorp1 = p1.GetComponent<SpriteRenderer>().color;
		colorp2 = p2.GetComponent<SpriteRenderer>().color;
		puntp1.text = "P1: " + punts1;
		puntp2.text = "P2: " + punts2;
  
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!fin) {
			if (!turn) {// turn player 1
				color.color = colorp1;
			} else { // Turn player 2
                color.color = colorp2;
			}
		
			if (g.IsTouchingLayers (LayerMask.GetMask ("murH"))) {
				if (punts1 < 2 && punts2 < 2) {
					r.velocity = new Vector2 (-7 * Mathf.Sign (r.velocity.x), r.velocity.y);

					if (g.IsTouching (esc)) { // mur esquerra
						if (turn) { //Turn p2
							punts1++;
							puntp1.text	= "P1: " + punts1;
							if(punts1 >= 2){
								final ();
							}
						} else { // Turn p1
							punts2++;
							puntp2.text = "P2: " + punts2;
							if(punts2 >= 2){
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
		} //FIN !FIN
	}
	void final(){
		fin = true;
		color.color = new Color (1f, 1f, 1f, 1f);
		bubbleW.GetComponent<SpriteRenderer>().color = colorp1;
		bubbleL.GetComponent<SpriteRenderer>().color = colorp2;
		bubbleW.SetActive(true);
		bubbleL.SetActive(true);
	}
}
