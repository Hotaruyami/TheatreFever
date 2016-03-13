using UnityEngine;
using System.Collections;

public class arcofiel : MonoBehaviour
{
    public cargar Anarsesala;

    private GameObject p1, p2;
    private Collider2D pumpu;
    private CircleCollider2D p1box;
    private player loco, loco2;
    private bool afegir, fin, nomas;
    private Vector3 B1, B2;

    public GameObject bubbleW, bubbleL;
    public bombolla bubledins1, bubledins2;
    public upgrade upgr;
    private bool finuncp;

    void Start()
    {
        afegir = fin = nomas = false;
        p1 = GameObject.FindGameObjectWithTag("player1");
        p2 = GameObject.FindGameObjectWithTag("player2");
        loco = p1.GetComponent<player>(); //Script p1
        loco2 = p2.GetComponent<player>();
        p1box = p1.GetComponent<CircleCollider2D>(); //CC del player
        pumpu = GetComponent<BoxCollider2D>(); //Collider de la sala

        finuncp = true;
       
    }

    void FixedUpdate()
    {


        if (p1box.IsTouching(pumpu))
        {
            if (!afegir)
            {
                //Activa arma  
                loco.activeWeap("arco");
                loco2.activeWeap("arco");
                afegir = true;

            }
            if (!fin)
            {
                if (loco.vida <= 0 || loco2.vida <= 0)
                {
                    if (finuncp)
                    {// final();
                        if (loco.vida > loco2.vida)
                        {
                            Anarsesala.acabar(true);
                        }
                        else
                        {
                            Anarsesala.acabar(false);
                        }
                        finuncp = false;

                    }
                }
            }

        }
    }






}