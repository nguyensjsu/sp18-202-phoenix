using UnityEngine.SceneManagement;

public class MenuReceiver : Receiver {
	public void doAction(string operation) {
		switch(operation) {
		case "Play":
			SceneManager.LoadScene(1);
			break;
		}
	}
}