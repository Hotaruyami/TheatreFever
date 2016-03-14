using UnityEngine;
using System.Collections;

public class arcofiel2 : MonoBehaviour
{
    public cargar Anarsesala;

	private GameObject p1, p2, mig1;
	private Collider2D arcofiel2col;
    private CircleCollider2D p1box;
    private player loco, loco2;
	private bool afegir, fin, nomas, finuncp, unactiven;
    private Vector3 B1, B2;

	public GameObject bubbleW, bubbleL, mig, pr1, pr2;
    public bombolla bubledins1, bubledins2;
    public upgrade upgr;

	//Script sala arcofiel2 on es fa servir Arco(arc horitzontal)

    void Start()
    {
        afegir = fin = nomas = false;
        p1 = GameObject.FindGameObjectWithTag("player1");
        p2 = GameObject.FindGameObjectWithTag("player2");
        loco = p1.GetComponent<player>(); //Script p1
        loco2 = p2.GetComponent<player>();
        p1box = p1.GetComponent<CircleCollider2D>(); //CC del player
        arcofiel2col = GetComponent<BoxCollider2D>();
		unactiven = finuncp = true;
       
    }

    void FixedUpdate()
    {


		if (p1box.IsTouching(arcofiel2col))
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
                if (p1.GetComponent<CircleCollider2D>().IsTouching(gameObject.GetComponent<BoxCollider2D>()))
                {
                    if (unactiven) {
                        mig1= Instantiate(mig, new Vector3(0, 0, 17), Quaternion.identity) as GameObject;
                        unactiven = false;
                    }
                    mig1.GetComponent<Rigidbody2D>().AddTorque(1000);
                }

                if (loco.vida <= 0 || loco2.vida <= 0)
                {
                    if (finuncp)
                    {// final();
                        if (loco.vida > loco2.vida)
                        {
                            Anarsesala.acabar(true,"fletxa");
                        }
                        else
                        {
                            Anarsesala.acabar(false,"fletxa");
                        }
                        finuncp = false;

                    }
                }
            }

        }
    }
}