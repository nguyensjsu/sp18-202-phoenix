using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class GameSystem : MonoBehaviour {

	abstract public void Initialize();
	abstract public void Play();

	public Text winner;

	public ArrayList monsters;
	public int numberOfMonsters;
	public int numberOfMonstersDestroyed;
	public bool isPaused;
	public bool isOver;
	public Timer timer;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void Run(){
		Initialize();
		Play ();
	}

	public void Init() {
		monsters = new ArrayList();
		numberOfMonsters = -1;
	}

	public void observePauseButton() {
		if (Input.GetButtonDown ("Cancel")) {
			ToggleGamePause ();
		}
	}

	public void observeMonsters() {
		if (numberOfMonsters - numberOfMonstersDestroyed == 0 && !isPaused) {
			isOver = true;
			ToggleGamePause ();
			winner.text = "You Won!";
		}
	}

	public void decreaseNumberOfMonsters() {
		numberOfMonstersDestroyed++;
	}

	private void ToggleGamePause() {
		if (Time.timeScale == 0) {
			Time.timeScale = 1;
			isPaused = false;
		} else {
			Time.timeScale = 0;
			isPaused = true;
		}
	}
}
