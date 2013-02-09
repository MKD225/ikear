using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUIScript : MonoBehaviour {
	
	public List<Transform> list;
	public Transform tracker;
	enum State { MAIN_MENU, BOYR_MODE, RL_MODE, ERROR }

    Transform clone, clone2;	
	
	State state = State.MAIN_MENU;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
		switch(state){
			case State.MAIN_MENU:
				DrawMainMenuGUI();
				break;
			case State.BOYR_MODE:
				DrawBoyrModeGUI();
				break;
			case State.RL_MODE:
				DrawRlModeGUI();
				break;
			case State.ERROR:
				DrawErrorGUI();
				break;
		}
	}
	
	void DrawMainMenuGUI(){
		GUILayout.BeginHorizontal();
		if(GUILayout.Button ("Build your own room", GUILayout.Height(100))){
			SetState (State.BOYR_MODE);
		}
		GUILayout.EndHorizontal();	
		
		GUILayout.BeginHorizontal();
		if(GUILayout.Button ("Reallife mode", GUILayout.Height(100))){
			SetState (State.RL_MODE);
		}
		GUILayout.EndHorizontal();	
		
		GUILayout.BeginHorizontal();

		if(GUILayout.Button ("Exit", GUILayout.Height(100))){
			Application.Quit();
	
		}
		GUILayout.EndHorizontal();	
		
		
	}
	
	void DrawBoyrModeGUI(){
		GUILayout.BeginHorizontal();
		if(GUILayout.Button ("Back to main menu", GUILayout.Height(100))){
			SetState(State.MAIN_MENU);				
		}
		GUILayout.EndHorizontal();	
		GUILayout.BeginHorizontal();
		
		foreach(Transform t in list){
			if(GUILayout.Button (t.name, GUILayout.Height(100))){	
				clone = Instantiate(t,new Vector3(0, 0, 0), Quaternion.identity) as Transform;			
				clone2 = Instantiate(t,new Vector3(3, 0, 3), Quaternion.identity) as Transform;
				clone.parent = tracker;
				clone2.parent = tracker;	
			}			
		}
		GUILayout.EndHorizontal();		
	}
	
	void DrawRlModeGUI(){
		GUILayout.BeginHorizontal();
		if(GUILayout.Button ("Back to main menu", GUILayout.Height(100))){
			SetState(State.MAIN_MENU);				
		}
		GUILayout.EndHorizontal();
	}
	
	void DrawErrorGUI(){
	}
	
	void SetState(State state){
		this.state = state;
	}
	
	
}
