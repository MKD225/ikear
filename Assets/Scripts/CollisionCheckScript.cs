using UnityEngine;
using System.Collections;

public class CollisionCheckScript : MonoBehaviour {
	

	bool triggered = false;
	Collider other;
	private Shader shader1 = Shader.Find ("Diffuse");
    private Shader shader2 = Shader.Find ("Diffuse-Test");

	
	void Start () {

	}
	
	void Update(){
		if(triggered && !other){
			exit ();
		}
	}
	
	void OnTriggerEnter(Collider other) {
		foreach (Transform t in this.transform) {
			t.renderer.material.color += new Color(0.5,0.2,0.2,1);
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
			t.renderer.material.color -= new Color(0.5,0.2,0.2,1);
		}  
		
	}
}
	