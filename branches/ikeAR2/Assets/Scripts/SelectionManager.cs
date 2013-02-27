using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectionManager : MonoBehaviour
{
	
	private GameObject oldselected, selected, oldmouseon, mouseon;
	private Color oldColor;
	private bool changedSelected;
	private Color oldOnMouseColor;
	private bool changedOnMouse;

	public GUIScript gui;
		
	public enum State{SELECTION, TRANSLATE, ROTATE};
	
	public State state = State.SELECTION;	
			
	
	Rect windowRect = new Rect(0,0,150,400);
	Vector2 mousePos;
	bool ignoreRaycast;
	
	
	// Use this for initialization
	void Start ()
	{
		changedSelected = false;
		changedOnMouse = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		mousePos.x = Input.mousePosition.x;
		mousePos.y = Screen.height - Input.mousePosition.y;
		
		ignoreRaycast = windowRect.Contains(mousePos);
		
		changedSelected = false;
		changedOnMouse = false;
		
		if(!ignoreRaycast){		
			mouseon = giveCastTarget ();
	
			//if mouse clicked -> select current rayhit 
			if (Input.GetMouseButtonDown (0) && state == State.SELECTION) {
				if (mouseon != null && selected != mouseon) {
					oldselected = selected;
					selected = mouseon;
					changedSelected = true;
					gui.SetState(GUIScript.State.EDIT_MODE);
				}
				if(mouseon == null && selected != null)
				{
					foreach (Transform t in selected.transform) {
						oldColor = t.renderer.material.color;
						t.renderer.material.color -= new Color (0.4F, 0.4F, 0.8F);
					}    
					oldselected = selected;
					selected = null;
				}
			}
			mouseOverColor ();	
			selectColor ();
		
			oldmouseon = mouseon;
		}
	
		if(selected){
			
			if (Input.GetKeyDown (KeyCode.Delete)) {
				selected.transform.Translate(Vector3.up * 5000);
				GameObject.Destroy (selected);
			}
			
			if(Input.GetKeyDown(KeyCode.UpArrow)){
				selected.transform.Translate(Vector3.up ,  Space.World);
			}
			else if(Input.GetKeyDown(KeyCode.DownArrow)){
				selected.transform.Translate(Vector3.down ,  Space.World);
			}						
			
			//translation
			if (Input.touchCount == 1 && Input.touches[0].phase == TouchPhase.Moved && (state == State.TRANSLATE)){
				Vector3 trans = new Vector3(Input.touches[0].deltaPosition.x, 0, Input.touches[0].deltaPosition.y)*0.4F;
				selected.transform.Translate(trans, Space.World);
			}				
			
		    //rorate        
		    if (Input.touchCount == 1 && Input.touches[0].phase == TouchPhase.Moved && (state == State.ROTATE)){
				selected.transform.Rotate(0, -Input.touches[0].deltaPosition.x, 0, Space.World);
			}

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
		if (Physics.Raycast (ray, out hit, 5500)) {
			if(hit.collider.gameObject.name != "Plane"){
			return hit.collider.gameObject;	
			}
		}
		return null;
	}
	
	public GameObject getSelected(){
		return selected;
	}
	
	public void deselect(){
		foreach (Transform t in selected.transform) {
			oldColor = t.renderer.material.color;
			t.renderer.material.color -= new Color (0.4F, 0.4F, 0.8F);
		}    
		oldselected = selected;
		selected = null;
	}
	
	public GameObject getOldSelected(){
		return oldselected;
	}
	
	public void setState(State state){
		this.state = state;
	}
		
}
