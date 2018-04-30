using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameLevel5 : GameSystem, IGameSystem {

	// change game level here
	private static int LEVEL = 5;

	private MonsterFactory mf;
	private ItemGenerator ig;

	void Start () {
		Run ();
	}

	void Update () {
		observePauseButton ();
		observeMonsters ();
	}

	public override void Initialize(){
		Init ();
		MovePattern.setInstance(LEVEL);
		ig = new ItemGenerator (0.8f); // items spawn rate
		mf = new MonsterFactory (new Vector3(-11.5f, 0.4f, 1));	// starting coordinate for enemies
	}

	public override void Play(){
		timer.Run ();
		StartCoroutine (Spawn());
		StartCoroutine (ig.Generate ());
	}

	// how the enemies will be spawned, use enum "Monsters" to select the enemy you want to spawn
	public IEnumerator Spawn() {
		monsters.Add(mf.getMonster(Monsters.bt));
		yield return new WaitForSeconds(2);
		monsters.Add(mf.getMonster(Monsters.bt));
		yield return new WaitForSeconds(2);
		monsters.Add(mf.getMonster(Monsters.bt));
		yield return new WaitForSeconds(2);
		numberOfMonsters = monsters.Count;
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

	public bool IsOver {
		get {
			return isOver;
		}
	}

}