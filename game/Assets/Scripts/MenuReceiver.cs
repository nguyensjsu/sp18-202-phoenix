using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuReceiver : Receiver {

	private GameObject menuPanel;
	private GameObject difficultyPanel;
	private GameObject controlsPanel;
    public DifficultyLevel difficultyLevel = DifficultyLevel.NewDifficultyLevelInstance();

	public void setPanels(GameObject m, GameObject d, GameObject a) {
		menuPanel = m;
		difficultyPanel = d;
		controlsPanel = a;
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
		case "Display Controls":
			menuPanel.SetActive(false);
			controlsPanel.SetActive(true);
			break;
		case "Quit":
			#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
			#else
				Application.Quit();
			#endif
			break;

		case "Easy Difficulty":
                difficultyLevel.setDifficulty(DifficultyType.EasyMode);
                break;
		case "Hard Difficulty":
                difficultyLevel.setDifficulty(DifficultyType.HardMode);
                break;
		case "Display Menu":
			if (difficultyPanel.activeSelf) {
				difficultyPanel.SetActive(false);
			} else {
				controlsPanel.SetActive(false);
			}

			menuPanel.SetActive(true);
			break;
		}
	}
}