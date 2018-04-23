using UnityEngine;

public class MainMenu : MonoBehaviour {

	private ICommand loadLevel1;

	void Start () {
		Receiver receiver = new MenuReceiver();
		loadLevel1 = new LoadLevelCommand();
		loadLevel1.setReceiver(receiver);
	}

	void OnGUI() {
		if (GUI.Button(new Rect(10, 10, 100, 50), "Start"))
			loadLevel1.execute();
	}
		
}
