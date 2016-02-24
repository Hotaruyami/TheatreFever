using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bola : MonoBehaviour {

	private Collider2D g, edc, esc;
	private Rigidbody2D r;
	private GameObject p1, p2;
	private bool turn,fin;
	private Color colorp1,colorp2;
	private Vector3 B1,B2;
	private int pun1,pun2;
	private Text puntp1, puntp2;
    public bombolla bubledins1, bubledins2;
	public GameObject es, ed, bubbleW, bubbleL,fonsi;
	public SpriteRenderer color;
    public cargar Anarsesala;
    private bool once;
	// Use this for initialization
	void Start () {
        once = false;
		pun1 = pun2 = 0;
		g = GetComponent <CircleCollider2D> ();
		r = GetComponent <Rigidbody2D>();
		edc = ed.GetComponent <BoxCollider2D> ();
		esc = es.GetComponent <BoxCollider2D> ();
		fin = turn = false; //turn false = tira player1
        p1 = GameObject.FindGameObjectWithTag("player1");
        p2 = GameObject.FindGameObjectWithTag("player2");
        fonsi = GameObject.FindGameObjectWithTag("fonstot");
        colorp1 = p1.GetComponent<SpriteRenderer>().color;
		colorp2 = p2.GetComponent<SpriteRenderer>().color;
		bubbleW.GetComponent<SpriteRenderer>().color = colorp1;
		bubbleL.GetComponent<SpriteRenderer>().color = colorp2;
		puntp1 = GameObject.Find("pplayer1").GetComponent<Text>();
		puntp2 = GameObject.Find("pplayer2").GetComponent<Text>();
		puntp1.text = "P1: " + pun1;
		puntp2.text = "P2: " + pun2;
	
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
				if (pun1 < 2 && pun2 < 2) {
					r.velocity = new Vector2 (-7 * Mathf.Sign (r.velocity.x), r.velocity.y);

					if (g.IsTouching (esc)) { // mur esquerra
						if (turn) { //Turn p2
							pun1++;
							puntp1.text = "P1: " + pun1;
							if(pun1 >= 2){
								final ();
							}
						} else { // Turn p1
							pun2++;
							puntp2.text = "P2: " + pun2;
							if(pun2 >= 2){
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
            print(Anarsesala.tamanySales()[0]);
            print(Anarsesala.tamanySales()[1]);
          
            if (!once)
            {
                fonsi.transform.position = new Vector3(fonsi.transform.position.x, fonsi.transform.position.y - Anarsesala.Next()-2, fonsi.transform.position.z);
                once = true;
            }
          
            
            
        }//FIN !FIN
	}
	void final(){
		fin = true;
		color.color = new Color (1f, 1f, 1f, 1f);
		B1 = new Vector3 (-7,-3,18);
		B2 = new Vector3 (7,-3,18);
		Instantiate (bubbleW,B2,Quaternion.identity);
		Instantiate (bubbleL,B1,Quaternion.identity);
		// Fer un destroy de la bola, amb una animació? (explosió)
	}
}
