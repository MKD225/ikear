using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUIScript : MonoBehaviour {
	
	public List<Transform> list;
	enum State { MAIN_MENU, BOYR_MODE, RL_MODE, ERROR }

	
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
		if(GUILayout.Button ("Build your own room")){
			SetState (State.BOYR_MODE);
		}
		GUILayout.EndHorizontal();	
		
		GUILayout.BeginHorizontal();
		if(GUILayout.Button ("Reallife mode")){
			SetState (State.RL_MODE);
		}
		GUILayout.EndHorizontal();	
		
		GUILayout.BeginHorizontal();

		if(GUILayout.Button ("Exit")){
			Application.Quit();
	
		}
		GUILayout.EndHorizontal();	
		
		
	}
	
	void DrawBoyrModeGUI(){
		GUILayout.BeginHorizontal();
		if(GUILayout.Button ("Back to main menu")){
			SetState(State.MAIN_MENU);				
		}
		GUILayout.EndHorizontal();	
		GUILayout.BeginHorizontal();
		if(GUILayout.Button ("CreateIt")){
			GameObject clone, clone2;
			clone = Instantiate(list[0],new Vector3(0, 0, 0), Quaternion.identity) as GameObject;

			
			clone2 = Instantiate(list[0],new Vector3(15, 0, 0), Quaternion.identity) as GameObject;

		}
		GUILayout.EndHorizontal();	
	}
	
	void DrawRlModeGUI(){
		GUILayout.BeginHorizontal();
		if(GUILayout.Button ("Back to main menu")){
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
