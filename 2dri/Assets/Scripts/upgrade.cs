using UnityEngine;
using System.Collections;


public class upgrade : MonoBehaviour {

	private bool upgra, p1escull, p2escull;

	static GameObject caixa; 
	static GameObject [] vec;
	static Vector3 pos;
	static Color[] tbanas;
	static Color[] a;
	static Color[] b;
	static Color[] c;
 	static Color[] s;

	// Use this for initialization
	void Start () {
		vec = new GameObject[4];
		pos = new Vector3 (0,0,0);
		upgra = false;
		p1escull = p2escull = true;
	}	//p1 a la dreta cuiao

	void FixedUpdate(){
		if (upgra) {
			if (p2escull) {
				if (Input.GetKeyDown (KeyCode.A)) {
					activar (vec [2].GetComponent<SpriteRenderer> ().color.ToString());
					p2escull = false;
					//en verdad no son colors, son sprites
				} else if (Input.GetKeyDown (KeyCode.D)) {
					activar (vec [3].GetComponent<SpriteRenderer> ().color.ToString());
					p2escull = false;
				}
			}
			if (p1escull) {
				if (Input.GetKeyDown (KeyCode.LeftArrow)) {
					activar (vec [0].GetComponent<SpriteRenderer> ().color.ToString());
					p1escull = false;
				} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
					activar (vec [1].GetComponent<SpriteRenderer> ().color.ToString());
					p1escull = false;
				}
			}
		}
	
	}

	public void dest(){ //Destrueix els upgradesBox
		GameObject[] games;
		games = (GameObject.FindGameObjectsWithTag ("upgra"));
		for(int i=0; i<games.Length; i++){
			Destroy (games [i]);

		}
	}

	public void comensa(bool p1win){
		p1escull = p2escull = true;
		editasio ();
		proses (p1win);
		upgra = true;
	}

	static void proses(bool p1win){ //Assigna dues millores als players
		float mitja1, mitja2;
		float puntalea;
		if (p1win) {
			mitja1 = 0.7f;
			mitja2 = 0.4f;
		
		} else {
			mitja1 = 0.4f;
			mitja2 = 0.7f;
		}
		for (int i = 0; i < 4; i++) 
		{
			if (i < 2) {
				while (true) {
					puntalea = upgrade.normal (Random.value, Random.value, mitja1);
					if (puntalea < 1 && puntalea > 0) {
						break;
					}
				}
				pos.Set (i*3+5.4f, 0.5f, 17);

			} 
			else 
			{
				while (true) {
					puntalea = upgrade.normal (Random.value, Random.value, mitja2);
					if (puntalea < 1 && puntalea > 0) {
						break;
					}
				}

				pos.Set (i*3-14.4f,0.5f, 17);
			}
			vec[i].GetComponent<SpriteRenderer>().color=escogecolors(puntalea);
			Instantiate(vec[i], pos, Quaternion.identity);
		}	
	}

	static void editasio(){ //Càrrega de scripts a un vector
		tbanas = new Color[1];
		a = new Color[1];
		b = new Color[1];
		s = new Color[1];
		c = new Color[1];

		a [0] = Color.red;
		b [0] = Color.magenta;
		c [0] = Color.grey;
		s [0] = Color.yellow;
		tbanas [0] = Color.black;

		vec = new GameObject[4];
		caixa = Resources.Load("upgradeCaixa", typeof(GameObject)) as GameObject;
		for (int i = 0; i < vec.Length; i++) {
			vec [i] = caixa;

		}
	}

	private static float normal(float u1, float u2, float mitja)
	{		
		double randStdNormal = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) * Mathf.Sin(2.0f * Mathf.PI * u2);
		double randNormal = mitja + 0.23f*randStdNormal;
		return (float) randNormal;
	}  

	static Color escogecolors(float puntalea) //Escull millores pels players
	{		
		if (puntalea < 0.2f) {
			return tbanas [Random.Range (0, tbanas.Length)];
		} else if (puntalea >= 0.2 && puntalea < 0.4) {
			return c [Random.Range (0, c.Length)];
		
		} else if (puntalea >= 0.4 && puntalea < 0.7) {
			return b [Random.Range (0, b.Length)];

		} else if (puntalea >= 0.7 && puntalea < 0.9) {
			return a [Random.Range (0, a.Length)];

		} else if (puntalea >= 0.9 && puntalea < 1) {
			return s [Random.Range (0, s.Length)];

		} else {
			return Color.white;
		}
	}  
	static void activar(string a) {
		//actualitzar player (dicicionaris, armadura, vida.... tbanas)
	}
}
