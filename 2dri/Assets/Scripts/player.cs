using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.UI;
using System.Collections.Generic;

public class player : MonoBehaviour {
    static Dictionary<string,string> armes;
	static float vidareal;
	public float vida,armadura;

	private GameObject arma,aa;
	private  Vector2 mov;
	private float p1h,p1v;

	void Start () {
		p1h = p1v = 0; 
		mov = new Vector2 (0, 0);
        armes = new Dictionary<string, string>();
        armes ["espasa"] = "espasa";
		armes ["arc"] = "arc";
		armes ["pal"] = "pal";
        armes["arco"] = "arco";
		vidareal = vida = 100f;
		armadura = 1;
	}

	void FixedUpdate () {
		
		if (gameObject.CompareTag ("player1")) {
			p1h = Input.GetAxis ("Horizontal"); 
			p1v = Input.GetAxis ("Vertical");

		}

		if(gameObject.CompareTag("player2"))
		{
			p1h = Input.GetAxis ("player2"); 
			p1v = Input.GetAxis ("player2v");

		}

		mov[0] = p1h; mov[1] = p1v;

		if(Mathf.Sqrt(p1h*p1h+p1v*p1v)>0){
			transform.position = new Vector3 (transform.position.x + p1h/Mathf.Sqrt(p1h*p1h+p1v*p1v)*0.2f, transform.position.y + p1v/Mathf.Sqrt(p1h*p1h+p1v*p1v) * 0.2F,17);	
		}

		if (vida < 0) {vida = 0;}
	}
    
	public string tornaupgrades(string arma){ //REtorna el tipus d'"arma"
        return armes[arma];
	}

	public void activeWeap(string nom){ //Activa l'arma nom
		arma = Resources.Load (nom, typeof(GameObject)) as GameObject;	
		aa = (Instantiate (arma, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject);
		aa.transform.parent = transform;
		if (nom == "pal") {
			aa.GetComponent<HingeJoint2D> ().connectedBody = gameObject.GetComponent<Rigidbody2D> ();
			aa.transform.localScale = new Vector3 (0.2f, 0.025f, 0);	
		} 
		else if (nom == "arc") {
			aa.transform.localScale = new Vector3 (0.2f,0.1f,0);
			aa.transform.localPosition = new Vector3 (0,0.07f,0);
		}
        else if (nom == "arco")
        {
            aa.transform.localScale = new Vector3(0.2f, 0.1f, 0);
            aa.transform.localPosition = new Vector3(0.09f, 0.0f, 0);
            aa.transform.rotation = Quaternion.Euler(0, 0, -90f);
        }
		else if (nom == "espasa") {
		}
	}

	public void desactivarWeap(string nom){
		Destroy(transform.FindChild (nom + "(Clone)").gameObject);
	}

	public void Obrir(bool obre){
		//Activa i desactiva players
		if(obre)
		{
          
			gameObject.SetActive (true);
		}
		else{
			gameObject.SetActive (false);
		}
	}

	public void Punts(int pun1, int pun2, bool active){
		if(active){
			GameObject.Find("pplayer1").GetComponent<Text>().text = "[P1]: " + pun1;
			GameObject.Find("pplayer2").GetComponent<Text>().text = "[P2]: " + pun2;	
		}
		else{ //Reset puntuació
			GameObject.Find("pplayer1").GetComponent<Text>().text = "";
			GameObject.Find("pplayer2").GetComponent<Text>().text = "";
		}

	}

    //puertas  de la vida
    public void vidarestaurar() {
       vida = vidarestaurarstatic();
    
    }
    static float vidarestaurarstatic() {
        return vidareal;
    }

    static void vidastaticcanviar(float upgradevida) {

        vidareal += upgradevida;
    }
}