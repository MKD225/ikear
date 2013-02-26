using UnityEngine;
using System.Collections;

public class CollisionCheckScript : MonoBehaviour {
	
	private Color originalColor;
	
	void Start () {
		if(this.transform.renderer != null)
		originalColor = this.transform.renderer.material.color;
	}
	
    void OnTriggerEnter(Collider other) {
		foreach (Transform t in other.transform) {
			t.renderer.material.color += new Color (0.2F, 0.8F, 0.2F);
		}   
		Debug.Log("Collision");        
    }
	
	void OnTriggerStay(Collider other){
	 	Debug.Log("Collision");
	}
	
	void OnTriggerExit(Collider other){		
		foreach (Transform t in other.transform) {
			t.renderer.material.color -= new Color (0.2F, 0.8F, 0.2F);
		}   
		Debug.Log("COLLISION EXIT");
	}
}
