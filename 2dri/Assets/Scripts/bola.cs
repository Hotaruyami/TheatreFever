using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bola : MonoBehaviour {
	private Collider2D g, edc, esc;
	private Rigidbody2D r; private bool toc;
	public GameObject es;
	public GameObject ed;
	public SpriteRenderer color;
	private bool turn,fin;
	private Color coli,coli2;
	public Text puntp1,puntp2;
	private int punts1, punts2;
	// Use this for initialization
	void Start () {
		punts1 = punts2 = 0;
		g = GetComponent <CircleCollider2D> ();
		r = GetComponent <Rigidbody2D> ();
		edc = ed.GetComponent <BoxCollider2D> ();
		esc = es.GetComponent <BoxCollider2D> ();
		toc = false;
		fin = false;
		turn = false;
		coli = new Color (0.407f, 0.749f, 0.509f,1f);
		coli2 = new Color (0.553f,0.376f,0.682f,1f);
		puntp1.text = "P1: " + punts1;
		puntp2.text = "P2: " + punts2;
		//turn false= tira player1
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (!fin) {
			if (!turn) {
				color.color = coli;
			} else {
				color.color = coli2;
			}
		
			if (g.IsTouchingLayers (LayerMask.GetMask ("murH"))) {
				if (punts1 < 10 && punts2 < 10) {
					r.velocity = new Vector2 (-7 * Mathf.Sign (r.velocity.x), r.velocity.y);
					if (g.IsTouching (esc)) {
						if (turn) {
							punts1++;
							puntp1.text	= "P1: " + punts1;
						} else {
							punts2++;
							puntp2.text = "P2: " + punts2;
						}

					}
					if (g.IsTouching (edc)) {
						if (!turn) {
							turn = true;
						} else if (turn) {
							turn = false;
						}
					}
				} else {
					fin = true;
					color.color = new Color (1f, 1f, 1f, 1f);
					//Final del joc, guanyador i tal
				}
			} 
			if (g.IsTouchingLayers (LayerMask.GetMask ("murY"))) {
			
				r.velocity = new Vector2 ((r.velocity.x), -7 * Mathf.Sign (r.velocity.y));

			}
		} else {
			//Fin
		}

	}
}
