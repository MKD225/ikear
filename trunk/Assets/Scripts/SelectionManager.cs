using UnityEngine;
using System.Collections;

public class SelectionManager : MonoBehaviour {
	
	private GameObject oldselected, selected, mouseon;
	private Color oldColor;
	private bool changedSelected;
	// Use this for initialization
	void Start () {
		changedSelected = false;
	}
	
	// Update is called once per frame
	void Update () {
	 changedSelected = false;
		mouseon = giveCastTarget();
  	 if ( Input.GetMouseButtonDown(0))
  	 {
		if(mouseon != null && selected != mouseon){
			oldselected = selected;
			selected = mouseon;
			changedSelected = true;
		}
   	 }
	
	if(selected != null && changedSelected){
		foreach(Transform t in selected.transform){
			oldColor = t.renderer.material.color;
			t.renderer.material.color += new Color(0.2F,0.2F, 0.2F);
		}    
	}
	
	if(changedSelected && oldselected != null){
		foreach(Transform t in oldselected.transform){
			t.renderer.material.color = oldColor;
		}   
	}
		
	if(Input.GetKeyDown(KeyCode.Delete)){
			GameObject.Destroy (selected);
	}
		
		
	}
	
	
	
	
	
	
	
	
	
	GameObject giveCastTarget(){
			 RaycastHit hit = new RaycastHit();
	      Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
	      if (Physics.Raycast(ray,out hit, 100))
	      {
	        return hit.collider.gameObject;	
	      }
			return null;
	}
	

}
