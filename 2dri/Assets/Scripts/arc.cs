using UnityEngine;
using System.Collections;

public class arc : MonoBehaviour {

	private GameObject p1,p2, bala,bala2;
	private Vector3 posBull, giren, pos;
    private float angle, modul, x1, y1;

	//Script de l'arc que es mou apuntant a l'enemic
	void Start () {
		p1 = GameObject.FindGameObjectWithTag("player1");
		p2 = GameObject.FindGameObjectWithTag("player2");
		bala = Resources.Load("balap2", typeof(GameObject)) as GameObject;
		bala2 = Resources.Load("balap1", typeof(GameObject)) as GameObject;
	}
	

	void Update () {
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
                posBull = new Vector3(transform.parent.position.x - 0.09f * x1, transform.parent.position.y - 0.09f * y1, transform.position.z);
                Instantiate(bala, posBull, Quaternion.Euler(0, 0, angle));
            }

        } //Fi player 2
        else 
		{

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


			if (Input.GetKeyDown(KeyCode.M)) //Player 1 dispara
            {
                posBull = new Vector3(transform.parent.position.x - 0.25f * x1, transform.parent.position.y - 0.25f * y1, transform.position.z);
				Instantiate(bala2, posBull, Quaternion.Euler(0, 0, angle));
            }
        }	//Fi player 1
	}

}
