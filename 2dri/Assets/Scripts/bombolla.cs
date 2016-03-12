using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class bombolla : MonoBehaviour {
	private GameObject p1, p2, b1, b2,bom;

	static bool uno,dos;
 
	public cargar Cn;

	void Start () {
        uno = false; dos = false;
		p1 = GameObject.FindGameObjectWithTag("player1");
		p2 = GameObject.FindGameObjectWithTag("player2");
		b1 = GameObject.FindGameObjectWithTag("b1");//Bubble1
		b2 = GameObject.FindGameObjectWithTag("b2");
	}
		
	void FixedUpdate () {   
		if (!uno) {
			if (p1.transform.position.x >= b1.transform.position.x - 1 && p1.transform.position.x <= b1.transform.position.x + 1 && p1.transform.position.y >= b1.transform.position.y - 1 && p1.transform.position.y <= b1.transform.position.y + 1) {
				//Si player 1 entra a la seva bubble, activem colliders perque no surti
				Walls (true, 1);
				uno = true;   
			} 
		} else if (uno && dos) {
			
			if ((p1.transform.position.x <= b1.transform.position.x - 3 || p1.transform.position.x >= b1.transform.position.x + 3 || p1.transform.position.y <= b1.transform.position.y - 3 || p1.transform.position.y >= b1.transform.position.y + 3) &&
			   (p2.transform.position.x <= b2.transform.position.x - 3 || p2.transform.position.x >= b2.transform.position.x + 3 || p2.transform.position.y <= b2.transform.position.y - 3 || p2.transform.position.y >= b2.transform.position.y + 3)) {
				Destroy (gameObject);//Eliminem bombolles
			} 

		}
        if (!dos){
            if (p2.transform.position.x >= b2.transform.position.x - 1 && p2.transform.position.x <= b2.transform.position.x + 1 && p2.transform.position.y >= b2.transform.position.y - 1 && p2.transform.position.y <= b2.transform.position.y + 1)
            {
				Walls (true,2);
                dos = true;
            }
        }
	}

	public void Walls(bool obre, int pu){
		if (pu == 1) {//Bubble1
			bom = b1.transform.Find("walls").gameObject; 
		} else if (pu == 2) {//Bubble2
			bom = b2.transform.Find("walls").gameObject;
		}

		if(obre){bom.SetActive (true);} //Obre bombolla
		else{bom.SetActive (false);} //tanca
	}

    public bool dins1() {return uno;}
    public bool dins2() {return dos;}
}
