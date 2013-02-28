using UnityEngine;
using System.Collections;

public class CollisionCheckScript : MonoBehaviour {
	

	bool triggered = false;
	Collider other;
	private Shader shader1 = Shader.Find ("Mobile/Diffuse");
    private Shader shader2 = Shader.Find ("Mobile/Diffuse-Highlight");

	
	void Start () {

	}
	
	void Update(){
		if(triggered && !other){
			exit ();
		}
	}
	
	void OnTriggerEnter(Collider other) {
		foreach (Transform t in this.transform) {
			t.renderer.material.shader = shader2;
		}   
		triggered = true;
		this.other = other;
		Debug.Log("Collision ENTER");        
    }
	
	void OnTriggerStay(Collider other){
	 //	Debug.Log("Collision" + " " + other.name);
	}
	
	void OnTriggerExit(Collider other){	
		 exit ();
	}
	
	void exit(){
		Debug.Log("COLLISION EXIT");
		triggered = false;
		foreach (Transform t in this.transform) {
			t.renderer.material.shader = shader1;
		}  
		
	}
}
	