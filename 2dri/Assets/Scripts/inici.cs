using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.SceneManagement;

public class inici : MonoBehaviour { 
	private BoxCollider2D parets;
	private GameObject random,random2,pg1, pg2;
	private SpriteRenderer p1, p2;
	private float p1v, p1h, p2v, p2h,i3,i4;
	private Vector3 posSala;
	private Color32[] cols;
    private int i1, i2;

	void Start () {
		pg1 = GameObject.FindGameObjectWithTag("player1");
		pg2 = GameObject.FindGameObjectWithTag("player2");
		p1 = pg1.GetComponent<SpriteRenderer> ();
		p2 = pg2.GetComponent<SpriteRenderer> ();
        cols = new Color32[5];
		cols[0]= new Color32(141,96,174,255);
		cols[1] = new Color32(104, 191, 130, 255);
        cols[2] = new Color32(0, 0, 0, 255);
        cols[3] = new Color32(20, 107, 193,255);
        cols[4] = new Color32(249, 86, 74, 255);
		i1 = 0;i2 = 1;
		i3 = i4 = 0;
		random = Resources.Load("random", typeof(GameObject)) as GameObject;
		random2 = Resources.Load("balap1", typeof(GameObject)) as GameObject;
    }

	void Update () {
		if((pg1.GetComponent<Collider2D>()).IsTouchingLayers(LayerMask.GetMask("MurIni"))){
			i3 = Random.Range(-3.0F, 3.0F);
			i4 = Random.Range(-3.0F, 3.0F);
			Instantiate(random, new Vector3(i4,i3,0), Quaternion.identity);
		}
		if((pg2.GetComponent<Collider2D>()).IsTouchingLayers(LayerMask.GetMask("MurIni"))){
			i3 = Random.Range(-3.0F, 3.0F);
			i4 = Random.Range(-3.0F, 3.0F);
			Instantiate(random2, new Vector3(i4,i3,0), Quaternion.identity);
		}
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            if(i2 == 4){ i2 = 0; } //canvia colors player esquerra
            else{ i2++; }
		}

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (i1 == 4){ i1 = 0; } //canvia colors player dreta
            else { i1++; }
        }

        p1.color = cols[i1]; // Asigna els colors als players
        p2.color = cols[i2];
        
		if (Input.GetKeyDown(KeyCode.Space) && i1 != i2 ) {  //Els players han de tenir colors diferents
			//Carrega l'escena on estan els jocs, sense destruir els players
          	DontDestroyOnLoad(pg1);
            DontDestroyOnLoad(pg2);
            SceneManager.LoadScene("Games"); 
         }
	}
}