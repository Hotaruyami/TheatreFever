using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class cargar : MonoBehaviour {

	public GameObject[] salas;
	private int ran,norep;
	private float tam;
	private Vector3 posSala;

	// Use this for initialization

	void Start () {
		tam = 0;
		norep = salas.Length + 1;
		//Pasar a la funció el número de minijocs a jugar?
		Jueguen ();

	}

	void Jueguen(){
		for(int x = 0; x < 2; ++x){
			ran = Random.Range (0, salas.Length);
			if (norep != ran) { // Mirem que no es repetexi sala
				posSala = new Vector3 (transform.position.x,tam, 18);
				Instantiate (salas [ran], posSala, Quaternion.identity);
				norep = ran; //Guardem la sala posada, per comprovar per la pròxima
				tam += salas[ran].transform.localScale.y+2; // guardem el tamany de la y de la sala ficada en pantalla
			} else {
				--x; //Si s'ha repetit, restem 1 a x, per repetir aquest bucle.
			}

		}
	}
	public void Next(){
		//Moure d'un stage a l'altre! Moure fons i sala o nomès sala, la càmara i les bombolles! el que sigui
		transform.position = new Vector3 (transform.position.x,transform.position.y-13,transform.position.z);
	}
		
//	public void CarPunt(int punts1, int punts2){
//		puntp1.text = "P1: " + punts1;
//		puntp2.text = "P2: " + punts2;
//	}

}
