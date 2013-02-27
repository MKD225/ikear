using UnityEngine;
using System.Collections;

public class CollisionCheckScript : MonoBehaviour {
	
	private Color[] originalColor;
	
	void Start () {
	
		if(this.transform.renderer != null){
			originalColor = new Color[this.transform.childCount];
			int i = 0;
			foreach(Transform t in this.transform)
			{
				originalColor[i] = t.renderer.material.color;
				i++;
			}
		}
	}
	
	void OnTriggerEnter(Collider other) {
		foreach (Transform t in other.transform) {
			t.renderer.material.color = Color.red;
		}   
		Debug.Log("Collision ENTER");        
    }
	
	void OnTriggerStay(Collider other){
	 	Debug.Log("Collision" + " " + other.name);
		
	}
	
	void OnTriggerExit(Collider other){		
		int i = 0;
		foreach (Transform t in other.transform) {
			t.renderer.material.color = originalColor[i];
		}   
		Debug.Log("COLLISION EXIT");
	}
}
