using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuReceiver : Receiver {

	private GameObject menuPanel;
	private GameObject difficultyPanel;
	private GameObject aboutPanel;

	public void setPanels(GameObject m, GameObject d, GameObject a) {
		menuPanel = m;
		difficultyPanel = d;
		aboutPanel = a;
	}

	public void doAction(string operation) {
		switch(operation) {
		case "Play":
			SceneManager.LoadScene(1);
			break;
		case "Display Difficulty":
			menuPanel.SetActive(false);
			difficultyPanel.SetActive(true);
			break;
		case "Display About":
			menuPanel.SetActive(false);
			aboutPanel.SetActive(true);
			break;
		case "Quit":
			#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
			#else
				Application.Quit();
			#endif
			break;

		case "Easy Difficulty":
			// TODO: Establish and implement easy strategy
			break;
		case "Hard Difficulty":
			// TODO: Establish and implement hard strategy
			break;
		case "Display Menu":
			if (difficultyPanel.activeSelf) {
				difficultyPanel.SetActive(false);
			} else {
				aboutPanel.SetActive(false);
			}

			menuPanel.SetActive(true);
			break;
		}
	}
}