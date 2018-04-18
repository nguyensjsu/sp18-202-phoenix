using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameLevel1 : GameSystem, IGameSystem {

	// change game level here
	private static int LEVEL = 1;

	private bool isPaused;
	private Timer timer;
	private MonsterFactory mf;

	void Start () {
		Run ();
	}

	void Update () {
		if (Input.GetButtonDown ("Cancel")) {
			isPaused = this.ToggleGamePause ();
		}
	}

	public override void Initialize(){
		isPaused = false;
		MovePattern.setInstance(LEVEL);

		mf = new MonsterFactory (new Vector3(-11.5f, 0.4f, 1));	// starting coordinate for enemies
		monsters = new ArrayList();
		StartCoroutine (Spawn());

		timer = GameObject.Find ("Canvas/Timer Text").GetComponent<Timer>();
	}

	public override void Play(){
		timer.Run ();
	}

	public override void End(){

	}

	// how the enemies will be spawned, use enum "Monsters" to select the enemy you want to spawn
	public IEnumerator Spawn() {
		monsters.Add(mf.getMonster(Monsters.bt));
		yield return new WaitForSeconds(2);
		monsters.Add(mf.getMonster(Monsters.bt));
		yield return new WaitForSeconds(2);
		monsters.Add(mf.getMonster(Monsters.bt));
		yield return new WaitForSeconds(2);
	}

	public int Level {
		get {
			return LEVEL;
		}
	}

	public bool IsPaused {
		get {
			return isPaused;
		}
	}

}