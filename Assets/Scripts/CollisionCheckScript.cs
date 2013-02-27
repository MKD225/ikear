using UnityEngine;
using System.Collections;

public class CollisionCheckScript : MonoBehaviour {
	

	bool triggered = false;
	Collider other;
	public Shader shader1 = Shader.Find("Diffuse");
    public Shader shader2 = Shader.Find("Diffuse Rim");
	
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
	