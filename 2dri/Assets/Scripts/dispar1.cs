using UnityEngine;
using System.Collections;

public class dispar1 : MonoBehaviour {
    private Vector3 rot; float x, y;  
	// Use this for initialization
	void Start () {
        rot = transform.rotation.eulerAngles;    
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1500 * Mathf.Cos(rot.z*Mathf.PI/180), 1500 * Mathf.Sin(rot.z*Mathf.PI/180)));
            
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
	}
}
