using UnityEngine;
using System.Collections;

public class arco : MonoBehaviour
{

    private GameObject p1, p2;
    private GameObject bala,bala2, fletxa;
    private Vector3 posBull;
    private float angle, modul, x1, y1;
    private Vector3 giren, pos;
    private float framespulsant;
    void Start()
    {
        //p1 = GameObject.FindGameObjectWithTag("player1");
        //p2 = GameObject.FindGameObjectWithTag("player2");
        framespulsant = 0;
        bala = Resources.Load("fletxa", typeof(GameObject)) as GameObject;
        bala2 = Resources.Load("fletxa2", typeof(GameObject)) as GameObject;
        if (transform.parent.tag == "player1") {
            transform.localPosition=new Vector3(-0.09f, 0, 17);
            transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
    }


    void FixedUpdate()
    {



        if (gameObject.transform.parent.tag == "player2")
        {


            if (Input.GetKey(KeyCode.LeftShift)) //Player 2 dispara
            {
                framespulsant++;



            }
            else {
                if (framespulsant > 0) {
                    
                   
                    fletxa = Instantiate(bala2, new Vector3(transform.parent.transform.position.x + 1f, transform.parent.transform.position.y, 17), Quaternion.Euler(0, 0, 0)) as GameObject;
                    fletxa.GetComponent<Rigidbody2D>().AddForce(new Vector2(80*framespulsant,0));
                    framespulsant = 0;
                    
                }
            }

        }
        else
        {

            if (Input.GetKey(KeyCode.RightShift)) //Player 1 dispara
            {

                    framespulsant++;


            }
            else {
                if (framespulsant > 0) {
                    fletxa = Instantiate(bala, new Vector3(transform.parent.transform.position.x - 1f, transform.parent.transform.position.y, 17), Quaternion.Euler(0, 0,180)) as GameObject;
                    fletxa.GetComponent<Rigidbody2D>().AddForce(new Vector2(-80 * framespulsant, 0));
                 
                    
                    framespulsant = 0;
                }
            }

              

            }
        
    

    }
}
