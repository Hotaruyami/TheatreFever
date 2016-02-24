using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class bombolla : MonoBehaviour {
	private GameObject p1, p2, b1, b2, bc1, bc2;
	static bool uno,dos;
	public cargar Cn;
    
   
	// Use this for initialization
	void Start () {
        uno = false; dos = false;
		p1 = GameObject.FindGameObjectWithTag("player1");
		p2 = GameObject.FindGameObjectWithTag("player2");
		b1 = GameObject.FindGameObjectWithTag("b1");
		b2 = GameObject.FindGameObjectWithTag("b2");
		bc1 = b1.transform.Find("walls").gameObject;
		bc2 = b2.transform.Find("walls").gameObject;
	}

	// Update is called once per frame
	void FixedUpdate () {
     
        if(!uno) {
            if (p1.transform.position.x >= b1.transform.position.x - 1 && p1.transform.position.x <= b1.transform.position.x + 1 && p1.transform.position.y >= b1.transform.position.y - 1 && p1.transform.position.y <= b1.transform.position.y + 1)
            {
                bc1.SetActive(true);
                uno = true;
              
            }
         
		}
        if (!dos)
        {
            if (p2.transform.position.x >= b2.transform.position.x - 1 && p2.transform.position.x <= b2.transform.position.x + 1 && p2.transform.position.y >= b2.transform.position.y - 1 && p2.transform.position.y <= b2.transform.position.y + 1)
            {
                bc2.SetActive(true);
                dos = true;


            }
        }
		
			
	}
    public bool dins1() {
        return uno;
    }
    public bool dins2() {
        return dos;
    }
}
