using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
public class cargar : MonoBehaviour {

	public GameObject[] salas;
    
	private BoxCollider2D pelotavasca;
    private int ran;
	private float tam,distanciapercanviar;
	private Vector3 posSala;
    private List<GameObject> sales;

 	static player pt1,pt2;
	static bombolla bm1,bm2;
    static GameObject p1,p2,b1,b2;
    static int index;
	static bool due,tre;
	static List<float> tamanys;

	void Start () {
		p1 = GameObject.FindGameObjectWithTag ("player1");
		p2 = GameObject.FindGameObjectWithTag ("player2");
		pt1 = p1.GetComponent<player>();
		pt2 = p2.GetComponent<player>();
		due = tre = false;
		tam = index = 0;
        tamanys = new List<float>();
        sales = salas.ToList<GameObject>();
		Jueguen ();	//Pasar a la funció el número de minijocs a jugar?
	}

	void FixedUpdate () {
		if (tre) { //Distancia a moure's
			distanciapercanviar = Next () + 2;
			tre = false;
		}
		else if(distanciapercanviar > 0 && due){//mou de sala
			transform.position = new Vector3 (transform.position.x, transform.position.y - 0.1f, transform.position.z);
			distanciapercanviar -= 0.1F;
		}
		else if (distanciapercanviar <= 0 && due){ //Destrueix la sala
			b1 = GameObject.FindGameObjectWithTag("b1");
			b2 = GameObject.FindGameObjectWithTag("b2");
			bm1 = b1.GetComponent<bombolla> ();
			bm2 = b2.GetComponent<bombolla> ();
			pelotavasca = GameObject.FindGameObjectWithTag ("sala1m").GetComponent<BoxCollider2D>();
			due = false;
			Destroy (pelotavasca.gameObject);
			pt1.Obrir (true);
			pt2.Obrir (true);
			bm1.Walls (false,1);
			bm2.Walls (false,2);
		}
	}

	void Jueguen(){
		for(int x = 0; x < 2; ++x){
			ran = Random.Range (0, sales.Count);
            tamanys.Add(sales[ran].transform.localScale.y);
			posSala = new Vector3 (transform.position.x,tam, 18);
            (Instantiate(sales[ran], posSala, Quaternion.identity) as GameObject).transform.parent = transform;
			tam += sales[ran].transform.localScale.y+2;
            sales.RemoveAt(ran);
		
		}
	}

	public float Next(){
      index+=1;
      return tamanys[index - 1];
        
	}

    public List<float> tamanySales() { return tamanys; }

	public void canviSala(){
		due = tre = true;
		pt1.Obrir (false);
		pt2.Obrir (false);
	}
}
