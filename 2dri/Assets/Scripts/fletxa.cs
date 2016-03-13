using UnityEngine;
using System.Collections;

public class fletxa : MonoBehaviour
{
    private Vector3 rot;
    float x, y;
    private bool tocamurs, nomasboladano, bolap1;
    private CircleCollider2D pc1, pc2;
    private Collider2D jo;
    private GameObject p1, p2;
    // Use this for initialization
    void Start()
    {
        jo = transform.GetComponent<PolygonCollider2D>();
        p1 = GameObject.FindGameObjectWithTag("player1");
        p2 = GameObject.FindGameObjectWithTag("player2");
        pc1 = p1.GetComponent<CircleCollider2D>();
        pc2 = p2.GetComponent<CircleCollider2D>();
        nomasboladano = false;

        if (gameObject.CompareTag("balap1"))
        {
            bolap1 = true;
        }
        else
        {
            bolap1 = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       

        if ( !nomasboladano)
        {
            if (jo.IsTouching(pc1) && !bolap1)
            {
                nomasboladano = true;
               p1.GetComponent<player>().vida -= 0.4f * Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.magnitude)*p1.GetComponent<player>().armadura;
             
            }
            if (jo.IsTouching(pc2) && bolap1)
            {
                nomasboladano = true;
               p2.GetComponent<player>().vida -= 0.4f * Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.magnitude)*p2.GetComponent<player>().armadura;
            }

        }

    }
}
