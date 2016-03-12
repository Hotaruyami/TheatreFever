using UnityEngine;
using System.Collections;

public class arc : MonoBehaviour {

	private GameObject p1,p2;
	private GameObject bala;
	private Vector3 posBull;
    private float angle, modul, x1, y1;
    private Vector3 giren, pos;
	void Start () {
		p1 = GameObject.FindGameObjectWithTag("player1");
		p2 = GameObject.FindGameObjectWithTag("player2");
	}
	

	void Update () {

       

        		//Pretenia fer un  as GameObject).transform.parent = p1.transform.FindChild("arc(Clone)");, pro aleshires les bales es mouen amb el player
		//I per alguna raó, es disparen dues bales cada cop xD
        if (gameObject.transform.parent.tag == "player2")
        {

            x1 = transform.parent.position.x - p1.transform.position.x;
            y1 = transform.parent.position.y - p1.transform.position.y;
            modul = Mathf.Sqrt(x1 * x1 + y1 * y1);
            x1 = x1 / modul; y1 = y1 / modul;
            if (y1 >= 0)
            {
                angle = Mathf.Acos(-x1) * 180 / Mathf.PI * -1;
                giren.Set(0f, 0f, -270 + Mathf.Acos(x1) * 180 / Mathf.PI);
            }
            else
            {
                angle = Mathf.Acos(-x1) * 180 / Mathf.PI;
                giren.Set(0f, 0f, +90 - Mathf.Acos(x1) * 180 / Mathf.PI);

            }
            pos.Set(-0.07f * x1, -0.07f * y1, 0);
            transform.rotation = Quaternion.Euler(giren);
            transform.localPosition = pos;




            if (Input.GetKeyDown(KeyCode.LeftShift)) //Player 2 dispara
            {
                bala = Resources.Load("balap2", typeof(GameObject)) as GameObject;
                posBull = new Vector3(transform.parent.position.x - 0.09f * x1, transform.parent.position.y - 0.09f * y1, transform.position.z);
                Instantiate(bala, posBull, Quaternion.Euler(0, 0, angle));


            }

        }
        else {

            x1 = transform.parent.position.x - p2.transform.position.x;
            y1 = transform.parent.position.y - p2.transform.position.y;
            modul = Mathf.Sqrt(x1 * x1 + y1 * y1);
            x1 = x1 / modul; y1 = y1 / modul;
            if (y1 >= 0)
            {
                angle = Mathf.Acos(-x1) * 180 / Mathf.PI * -1;
                giren.Set(0f, 0f, -270 + Mathf.Acos(x1) * 180 / Mathf.PI);
            }
            else
            {
                angle = Mathf.Acos(-x1) * 180 / Mathf.PI;
                giren.Set(0f, 0f, +90 - Mathf.Acos(x1) * 180 / Mathf.PI);

            }
            pos.Set(-0.07f * x1, -0.07f * y1, 0);
            transform.rotation = Quaternion.Euler(giren);
            transform.localPosition = pos;




            if (Input.GetKeyDown(KeyCode.RightShift)) //Player 1 dispara
            {
                bala = Resources.Load("balap1", typeof(GameObject)) as GameObject;
                posBull = new Vector3(transform.parent.position.x - 0.25f * x1, transform.parent.position.y - 0.25f * y1, transform.position.z);
				Instantiate(bala, posBull, Quaternion.Euler(0, 0, angle));


            }
        }
//		if (Input.GetKeyDown (KeyCode.M)) //Player 1 dispara
//		{
//			bala = Resources.Load ("bala", typeof(GameObject)) as GameObject;	
//			posBull = new Vector3 (p1.transform.position.x,p1.transform.position.y+1,p1.transform.position.z);
//			Instantiate (bala, posBull, Quaternion.identity);
//		} 
	
	}
}
