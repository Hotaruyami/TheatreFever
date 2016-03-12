using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
public class cargar : MonoBehaviour {

	public GameObject[] salas;
    
    private int ran;
	private float tam,distanciapercanviar;
	private Vector3 posSala;
    private List<GameObject> sales;
	public upgrade up;


	static Collider2D sala;
 	static player pt1,pt2;
	static bombolla bm1,bm2;
    static GameObject p1,p2,b1,b2;
    static int index;
	static bool due,tre;
	static List<float> tamanys;

	void Start () {
		p1 = GameObject.FindGameObjectWithTag ("player1");
		p2 = GameObject.FindGameObjectWithTag ("player2");
		pt1 = p1.GetComponent<player>(); //Script player1
		pt2 = p2.GetComponent<player>();
		due = tre = false;
		tam = index = 0;
        tamanys = new List<float>();
        sales = salas.ToList<GameObject>();
		Jueguen ();	//Executa el creador de sales
		//Pasar a la funció el número de minijocs a jugar?

	}

	void FixedUpdate () {
			GameObject.Find("vidap2").GetComponent<Text>().text = "HP: " + pt1.vida;
			GameObject.Find("vidap1").GetComponent<Text>().text = "HP: " + pt2.vida;//de moment, tal funcio


		if (tre) { //Distancia a moure's
			distanciapercanviar = Next () + 2;
			tre = false;
		}
		else if(distanciapercanviar > 0 && due){//mou de sala
			transform.position = new Vector3 (transform.position.x, transform.position.y - 0.1f, transform.position.z);
			distanciapercanviar -= 0.1F;
		}
		else if (distanciapercanviar <= 0 && due){ //Destrueix la sala
			b1 = GameObject.FindGameObjectWithTag("b1"); //Bombolles
			b2 = GameObject.FindGameObjectWithTag("b2");
			bm1 = b1.GetComponent<bombolla> (); //Script bombolla 1
			bm2 = b2.GetComponent<bombolla> ();
			due = false;
			up.dest();
			DestroySala (); //Destruim sala anterior
			pt1.Obrir (true); //Fa apareixer el player 1
			pt2.Obrir (true);
			bm1.Walls (false,1); //Obre les portes de la bombolla
			bm2.Walls (false,2);
		}
	}

	void Jueguen(){
		for(int x = 0; x < 3; ++x){ // fa un for i carrega el número de sales (de moment son 2)
			ran = Random.Range (0, sales.Count); //sala aleatoria
            tamanys.Add(sales[ran].transform.localScale.y); //Afegeix a tamanys el tamany de la sala actual
			posSala = new Vector3 (transform.position.x,tam, 18); //Posisció on es col·locarà
            (Instantiate(sales[ran], posSala, Quaternion.identity) as GameObject).transform.parent = transform; //Instancia i la fa child de fons
			tam += sales[ran].transform.localScale.y+2;
            sales.RemoveAt(ran);
		}
	}

	public float Next(){ //Calcula el tamany de la sala i el retorna
      index += 1;
      return tamanys[index - 1];     
	}

    public List<float> tamanySales() { return tamanys; } 

	public void canviSala(){
		due = tre = true;
		pt1.Obrir (false); //esactiva els players while bubble
		pt2.Obrir (false);

	}
	public void AsignSalaDelete(Collider2D delete){
		sala = delete; //Fem arribar aquí, el collider de la sala on estem, per fer delete
	}

	void DestroySala(){
		Destroy (sala.gameObject); //Destruim sala anterior
	}

}
