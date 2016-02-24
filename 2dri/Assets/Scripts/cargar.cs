using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
public class cargar : MonoBehaviour {

	public GameObject[] salas;
    static List<float> tamanys;
    private int ran;
	private float tam;
	private Vector3 posSala;
    private List<GameObject> sales;
    static int index;
	// Use this for initialization

	void Start () {
		tam = 0;
		
		//Pasar a la funció el número de minijocs a jugar?
        index = 0;
        tamanys = new List<float>();
        sales = salas.ToList<GameObject>();
		Jueguen ();


	}

	void Jueguen(){
		for(int x = 0; x < 2; ++x){
			ran = Random.Range (0, sales.Count);
            tamanys.Add(sales[ran].transform.localScale.y);
		//	if (norep != ran) { // Mirem que no es repetexi sala
				posSala = new Vector3 (transform.position.x,tam, 18);
			//	Instantiate (sales [ran], posSala, Quaternion.identity);
                (Instantiate(sales[ran], posSala, Quaternion.identity) as GameObject).transform.parent = transform;
				//norep = ran; //Guardem la sala posada, per comprovar per la pròxima
				tam += sales[ran].transform.localScale.y+2;
                sales.RemoveAt(ran);
            // guardem el tamany de la y de la sala ficada en pantalla
			//} 

		}
	}
	public float Next(){
		//Moure d'un stage a l'altre! Moure fons i sala o nomès sala, la càmara i les bombolles! el que sigui
		//transform.position = new Vector3 (transform.position.x,transform.position.y-13,transform.position.z);
      index+=1;
      return tamanys[index - 1];
        
	}
    public List<float> tamanySales() { return tamanys; }
//	public void CarPunt(int punts1, int punts2){
//		puntp1.text = "P1: " + punts1;
//		puntp2.text = "P2: " + punts2;
//	}

}
