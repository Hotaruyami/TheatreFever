using System.Collections;
using UnityEngine;

public class bola : MonoBehaviour
{
    private Collider2D g, edc, esc, pelotavasca;
    private Rigidbody2D r, p1R, p2R;
    private GameObject p1, p2, pal;
    private bool turn, fin, afegir, nomas;
    private Color colorp1, colorp2;
    private int pun1, pun2;
    private player loco, loco2;
    private CircleCollider2D p1box;
    private SpriteRenderer colorWD;


    public GameObject es, ed;
    public cargar Anarsesala;
    public upgrade upgr;
    void Start()
    {
        afegir = nomas = false;
        pun1 = pun2 = 0;
        p1 = GameObject.FindGameObjectWithTag("player1");
        p2 = GameObject.FindGameObjectWithTag("player2");
        g = GetComponent<CircleCollider2D>();//CC de la bola
        r = GetComponent<Rigidbody2D>();
        p1box = p1.GetComponent<CircleCollider2D>(); //CC del player
        edc = ed.GetComponent<BoxCollider2D>();//Wall dreta  
        esc = es.GetComponent<BoxCollider2D>();
        colorWD = ed.GetComponent<SpriteRenderer>();
        fin = turn = false; //turn false = tira player1
        colorp1 = p1.GetComponent<SpriteRenderer>().color;
        colorp2 = p2.GetComponent<SpriteRenderer>().color;

        loco = p1.GetComponent<player>();
        loco2 = p2.GetComponent<player>();
        pelotavasca = GameObject.FindGameObjectWithTag("sala1m").GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        if (p1box.IsTouching(pelotavasca))
        {

            if (!afegir)
            {
                if (p1box.IsTouching(pelotavasca))
                {
                    loco.Punts(pun1, pun2, true); //Activa el sistema de punts
                    //Activa arma  
                    loco.activeWeap("pal");
                    loco2.activeWeap("pal");
                    afegir = true;
                }
            }

            if (!fin)
            {
                if (!turn)
                {
                    colorWD.color = colorp1;
                } // turn player 1
                else
                {
                    colorWD.color = colorp2;
                } // Turn player 2

                if (g.IsTouchingLayers(LayerMask.GetMask("murH")))
                {
                    if (pun1 < 1 && pun2 < 1)
                    {
                        r.velocity = new Vector2(-7 * Mathf.Sign(r.velocity.x), r.velocity.y);

                        if (g.IsTouching(esc))
                        { // mur esquerra
                            if (turn)
                            {
                                pun1++;
                            } //Turn p2
                            else
                            {
                                pun2++;
                            } // Turn p1
                            loco.Punts(pun1, pun2, true);
                            if (pun1 >= 1 || pun2 >= 1)
                            {
                                if (pun1 > pun2)
                                {
                                    Anarsesala.acabar(true);
                                }
                                else {
                                    Anarsesala.acabar(false);
                                }
                               
                                final();

                            }
                        }
                        if (g.IsTouching(edc))
                        { // mur dret
                            if (!turn)
                            {
                                turn = true;
                            }
                            else if (turn)
                            {
                                turn = false;
                            }
                        }
                    }
                } //FIN MUR H

                if (g.IsTouchingLayers(LayerMask.GetMask("murY")))
                {
                    r.velocity = new Vector2((r.velocity.x), -7 * Mathf.Sign(r.velocity.y));
                } //FIN MUR Y
            }
            
         
        }
    }  

    void final()
    {
        Destroy(gameObject);
    }
}
