using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUIScript : MonoBehaviour {

    private int FURN_BUTTON_HEIGHT = 100,
                MENU_BUTTON_HEIGHT = 100;
	public List<Transform> list;
	public Transform tracker;
	enum State { MAIN_MENU, BOYR_MODE, RL_MODE, ERROR }
	public Vector2 scrollPosition = Vector2.zero;

    Transform clone;	
	
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
        if (GUILayout.Button("Build your own room", GUILayout.Height(MENU_BUTTON_HEIGHT)))
        {
			SetState (State.BOYR_MODE);
		}
		GUILayout.EndHorizontal();	
		
		GUILayout.BeginHorizontal();
        if (GUILayout.Button("Reallife mode", GUILayout.Height(MENU_BUTTON_HEIGHT)))
        {
			SetState (State.RL_MODE);
		}
		GUILayout.EndHorizontal();	
		
		GUILayout.BeginHorizontal();

        if (GUILayout.Button("Exit", GUILayout.Height(MENU_BUTTON_HEIGHT)))
        {
			Application.Quit();
	
		}
		GUILayout.EndHorizontal();	
		
		
	}

    void DrawRlModeGUI()
    {
		
		GUILayout.BeginHorizontal();
		if(GUILayout.Button ("Back to main menu", GUILayout.Height(MENU_BUTTON_HEIGHT))){
			SetState(State.MAIN_MENU);				
		}
		GUILayout.EndHorizontal();

        scrollPosition = GUI.BeginScrollView(new Rect(10, 150, 150, 600), scrollPosition, new Rect(0, 0, 120, list.Count * FURN_BUTTON_HEIGHT), false, true);
		
		
		foreach(Transform t in list){
			GUILayout.BeginHorizontal();
            if (GUILayout.Button(Resources.Load(t.name) as Texture2D))   // PRECONDITION: Bild mit namen des Prefabs ind er Liste muss im Resources Ordner liegen - 125 * 90 PX
            {	
				clone = Instantiate(t,new Vector3(0, 0, 0), Quaternion.identity) as Transform;			

				clone.parent = tracker;

			}	
			GUILayout.EndHorizontal();		
		}
		
		GUI.EndScrollView();
	}

    void DrawBoyrModeGUI()
    {
		GUILayout.BeginHorizontal();
        if (GUILayout.Button("Back to main menu", GUILayout.Height(FURN_BUTTON_HEIGHT)))
        {
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
