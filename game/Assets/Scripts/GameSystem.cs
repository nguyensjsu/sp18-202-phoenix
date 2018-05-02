using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class GameSystem : MonoBehaviour {

	abstract public void Initialize();
	abstract public void Play();

	public Text winner;

	public List<Vector3> startingCoordinates;
	public ArrayList monsters;
	public int numberOfMonsters;
	public int numberOfMonstersDestroyed;
	public bool isPaused;
	public bool isOver;
	public Timer timer;


	public List<MonsterFactory> mfs;
	public ItemGenerator ig;

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
		startingCoordinates = new List<Vector3>();
		mfs = new List<MonsterFactory>();
		monsters = new ArrayList();
		numberOfMonsters = -1;
	}

	public void ObservePauseButton() {
		if (Input.GetButtonDown ("Cancel")) {
			ToggleGamePause ();
		}
	}

	public void ObserveMonsters() {
		if (numberOfMonsters - numberOfMonstersDestroyed == 0 && !isPaused) {
			isOver = true;
			ToggleGamePause ();
			winner.text = "You Won!";
		}
	}

	public void DecreaseNumberOfMonsters() {
		numberOfMonstersDestroyed++;
	}

	public void SetUp() {
		for (int i = 0; i < startingCoordinates.Count; i++) {
			mfs.Add(new MonsterFactory (startingCoordinates[i]));
		}
	}

	public void SetRoute(GameObject monster) {
		for (int route = 0; route < startingCoordinates.Count; route++) {
			if (monster.transform.position == startingCoordinates [route]) {
				monster.GetComponent<IMonster> ().Route = route;
			}
		}
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
