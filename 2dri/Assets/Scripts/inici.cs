using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.SceneManagement;

public class inici : MonoBehaviour {
    public SpriteRenderer p1, p2;
    public GameObject pg1, pg2;

	private float p1v, p1h, p2v, p2h;
	private Vector3 posSala;
	private Color32[] cols;
    private int i1, i2;

	void Start () {
        cols = new Color32[5];
		cols[0]= new Color32(141,96,174,255);
		cols[1] = new Color32(104, 191, 130, 255);
        cols[2] = new Color32(0, 0, 0, 255);
        cols[3] = new Color32(20, 107, 193,255);
        cols[4] = new Color32(249, 86, 74, 255);
        i1 = 0;i2 = 1;
    }

	void Update () {
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            if(i2 == 4){ i2=0; }
            else{ i2++; }
		}

        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            if (i1 == 4){ i1 = 0; }
            else { i1++; }
        }

        p1.color = cols[i1];
        p2.color = cols[i2];
        
		if (Input.GetKeyDown(KeyCode.Space)) {
          	DontDestroyOnLoad(pg1);
            DontDestroyOnLoad(pg2);
            SceneManager.LoadScene("Games"); 
         }
	}
}