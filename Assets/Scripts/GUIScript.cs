using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUIScript : MonoBehaviour {

    private int FURN_BUTTON_HEIGHT = 100,
                MENU_BUTTON_HEIGHT = 100;
	public List<Transform> list;
	public Transform tracker;
	public enum State { MAIN_MENU, BOYR_MODE, RL_MODE, EDIT, EDIT_MODE, ERROR}
	public Vector2 scrollPosition = Vector2.zero;

    Transform clone;
	
	private List<Transform> objects = new List<Transform>();
	
	public SelectionManager sManager;
	
	private State state = State.MAIN_MENU;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(sManager.getSelected() != null) SetState(State.EDIT_MODE);
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
			case State.EDIT:
				DrawEditBtn();
				break;
			case State.EDIT_MODE:
				DrawEditGUI();
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

        scrollPosition = GUI.BeginScrollView(new Rect(0, 100, 150, Mathf.Min(600,list.Count * FURN_BUTTON_HEIGHT)), scrollPosition, new Rect(0, 100, 120, list.Count * FURN_BUTTON_HEIGHT), false, 600  < list.Count * FURN_BUTTON_HEIGHT);
				
		foreach(Transform t in list){
			GUILayout.BeginHorizontal();
            if (GUILayout.Button(Resources.Load(t.name) as Texture2D))   // PRECONDITION: Bild mit namen des Prefabs ind er Liste muss im Resources Ordner liegen - 125 * 90 PX
            {	
				clone = Instantiate(t,new Vector3(0, 0, 0), Quaternion.identity) as Transform;			

				clone.parent = tracker;
				objects.Add (clone);
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
	
	void DrawEditBtn(){
		GUILayout.BeginVertical();
        if (GUILayout.Button("Edit", GUILayout.Height(FURN_BUTTON_HEIGHT), GUILayout.Width(150)))
        {
			SetState(State.EDIT_MODE);
		}
		GUILayout.EndHorizontal();
	}	
	
	void DrawEditGUI(){
		GUILayout.BeginHorizontal();
        if (GUILayout.Button("Move", GUILayout.Height(FURN_BUTTON_HEIGHT), GUILayout.Width(150)))
        {
			sManager.setState(SelectionManager.State.TRANSLATE);
			//sManager.state = SelectionManager.State.TRANSLATE;			
		}
		GUILayout.EndHorizontal();
		
		GUILayout.BeginHorizontal();
        if (GUILayout.Button("Rotate", GUILayout.Height(FURN_BUTTON_HEIGHT)))
        {
			sManager.setState(SelectionManager.State.ROTATE);
			//sManager.state = SelectionManager.State.ROTATE;					
		}
		GUILayout.EndHorizontal();
			
		GUILayout.BeginHorizontal();
        if (GUILayout.Button("Remove", GUILayout.Height(FURN_BUTTON_HEIGHT)))
        {
			sManager.setSelected ();
			GameObject.Destroy(sManager.getOldSelected());			
			sManager.setState(SelectionManager.State.SELECTION);
			SetState(State.MAIN_MENU);	
		}
		GUILayout.EndHorizontal();
		
		GUILayout.BeginHorizontal();
        if (GUILayout.Button("Cancel", GUILayout.Height(FURN_BUTTON_HEIGHT)))
        {
			sManager.setState(SelectionManager.State.SELECTION);
			//sManager.state = SelectionManager.State.SELECTION;
			SetState(State.MAIN_MENU);				
		}
		GUILayout.EndHorizontal();
	}
		public void setState(State state){
		this.state = state;
	}
   
}
