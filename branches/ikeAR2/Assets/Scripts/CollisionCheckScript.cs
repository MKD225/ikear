using UnityEngine;
using System.Collections;

public class CollisionCheckScript : MonoBehaviour {
	
	private Color originalColor;
	
	void Start () {
		if(this.transform.renderer != null)
		originalColor = this.transform.renderer.material.color;
	}
	
    void OnTriggerEnter(Collider other) {

   	 Debug.Log("Collision");
        
    }
	
	void OnTriggerStay(Collider other){
	 Debug.Log("Collision");
	}
	
	void OnTriggerExit(Collider other){
		Debug.Log("COLLISION EXIT");
	}
}
