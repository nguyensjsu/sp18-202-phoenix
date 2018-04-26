using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public GameObject menuPanel;
	public GameObject difficultyPanel;
	public GameObject aboutPanel;

	public Button startButton;
	public Button difficultyButton;
	public Button aboutButton;
	public Button quitButton;
	public Button easyButton;
	public Button hardButton;
	public Image easyButtonImage;
	public Image hardButtonImage;
	public Button difficultyBackButton;
	public Button aboutBackButton;

	private ICommand loadLevel1;
	private ICommand displayDifficultyPanel;
	private ICommand displayAboutPanel;
	private ICommand quitGame;
	private ICommand selectEasyDifficulty;
	private ICommand selectHardDifficulty;
	private ICommand displayMenu;

	private bool easySelected = true;

	void Start () {
		MenuReceiver receiver = new MenuReceiver();
		receiver.setPanels(menuPanel, difficultyPanel, aboutPanel);
		hardButtonImage.enabled = false;

		loadLevel1 = new LoadLevelCommand();
		displayDifficultyPanel = new DisplayDifficultyPanelCommand();
		displayAboutPanel = new DisplayAboutPanelCommand();
		quitGame = new QuitGameCommand();

		selectEasyDifficulty = new SelectEasyDifficultyCommand();
		selectHardDifficulty = new SelectHardDifficultyCommand();
		displayMenu = new DisplayMenuPanelCommand();

		loadLevel1.setReceiver(receiver);
		displayDifficultyPanel.setReceiver(receiver);
		displayAboutPanel.setReceiver(receiver);
		quitGame.setReceiver(receiver);
		selectEasyDifficulty.setReceiver(receiver);
		selectHardDifficulty.setReceiver(receiver);
		displayMenu.setReceiver(receiver);

		startButton.onClick.AddListener(handleStartButtonClick);
		difficultyButton.onClick.AddListener(handleDifficultyButtonClick);
		aboutButton.onClick.AddListener(handleAboutButtonClick);
		quitButton.onClick.AddListener(handleQuitButtonClick);
		easyButton.onClick.AddListener(handleEasyButtonClick);
		hardButton.onClick.AddListener(handleHardButtonClick);
		difficultyBackButton.onClick.AddListener(handleBackButtonClick);
		aboutBackButton.onClick.AddListener(handleBackButtonClick);
	}

	private void handleStartButtonClick() {
		loadLevel1.execute();
	}

	private void handleDifficultyButtonClick() {
		displayDifficultyPanel.execute();
	}

	private void handleAboutButtonClick() {
		displayAboutPanel.execute();
	}

	private void handleQuitButtonClick() {
		quitGame.execute();
	}

	private void handleEasyButtonClick() {
		easySelected = true;
		selectEasyDifficulty.execute();
	}

	private void handleHardButtonClick() {
		easySelected = false;
		selectHardDifficulty.execute();
	}

	private void handleBackButtonClick() {
		displayMenu.execute();
	}

	public void Update() {
		if (easySelected) {
			easyButtonImage.enabled = true;
			hardButtonImage.enabled = false;
		} else {
			easyButtonImage.enabled = false;
			hardButtonImage.enabled = true;
		}
	}
}
