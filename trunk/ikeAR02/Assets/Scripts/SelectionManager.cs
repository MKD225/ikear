using UnityEngine;
using System.Collections;

public class SelectionManager : MonoBehaviour
{
	
	private GameObject oldselected, selected, oldmouseon, mouseon;
	private Color oldColor;
	private bool changedSelected;
	private Color oldOnMouseColor;
	private bool changedOnMouse;
	// Use this for initialization
	void Start ()
	{
		changedSelected = false;
		changedOnMouse = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		changedSelected = false;
		changedOnMouse = false;
		mouseon = giveCastTarget ();
		
		//if mouse clicked -> select current rayhit 
		if (Input.GetMouseButtonDown (0)) {
			if (mouseon != null && selected != mouseon) {
				oldselected = selected;
				selected = mouseon;
				changedSelected = true;
			}
		}
		mouseOverColor ();	
		selectColor ();
	
		oldmouseon = mouseon;	
	
		
		if (Input.GetKeyDown (KeyCode.Delete)) {
			GameObject.Destroy (selected);
		}
		
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			selected.transform.Translate(Vector3.up ,  Space.World);
		}
		else if(Input.GetKeyDown(KeyCode.DownArrow)){
			selected.transform.Translate(Vector3.down ,  Space.World);
		}
	}
	
	void mouseOverColor ()
	{
		if (oldmouseon != mouseon) {
		
			changedOnMouse = true;
		}
		
		if (changedOnMouse && oldmouseon != null) {
			
			foreach (Transform t in oldmouseon.transform) {
				t.renderer.material.color -= new Color (0.8F, 0.2F, 0.2F);
			}   
		}
		
		if (mouseon != null && changedOnMouse) {
			foreach (Transform t in mouseon.transform) {
				oldOnMouseColor = t.renderer.material.color;
				t.renderer.material.color += new Color (0.8F, 0.2F, 0.2F);
			
			
			} 
		
		}
	}
	
	void selectColor ()
	{
		if (selected != null && changedSelected) {
			foreach (Transform t in selected.transform) {
				oldColor = t.renderer.material.color;
				t.renderer.material.color += new Color (0.4F, 0.4F, 0.8F);
			}    
		}
	
		if (changedSelected && oldselected != null) {
			foreach (Transform t in oldselected.transform) {
				t.renderer.material.color -= new Color (0.4F, 0.4F, 0.8F);
			}   
		}		
		

	}

	GameObject giveCastTarget ()
	{
		RaycastHit hit = new RaycastHit ();
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit, 100)) {
			return hit.collider.gameObject;	
		}
		return null;
	}
	

}
