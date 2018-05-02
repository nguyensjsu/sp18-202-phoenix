using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameLevel5 : GameSystem, IGameSystem {

	// change game level here
	private static int LEVEL = 5;

	private MonsterFactory mf_top;
	private MonsterFactory mf_middle;
	private MonsterFactory mf_bottom;
	private ItemGenerator ig;

	void Start () {
		Run ();
	}

	void Update () {
		ObservePauseButton ();
		ObserveMonsters ();
	}

	public override void Initialize(){
		Init ();
		MovePattern.setInstance(LEVEL);
		ig = new ItemGenerator (0.8f); // items spawn rate
		mf_top = new MonsterFactory (new Vector3(-11.5f, 4f, 1));	// starting coordinate for enemies
		mf_middle = new MonsterFactory (new Vector3(-11.5f, 0.4f, 1));
		mf_bottom = new MonsterFactory (new Vector3(-11.5f, -3.7f, 1));
	}

	public override void Play(){
		timer.Run ();
		StartCoroutine (Spawn());
		StartCoroutine (ig.Generate ());
	}

	// how the enemies will be spawned, use enum "Monsters" to select the enemy you want to spawn
	public IEnumerator Spawn() {
		monsters.Add(mf_top.getMonster(Monsters.bt));
		yield return new WaitForSeconds(2);
		monsters.Add(mf_middle.getMonster(Monsters.bt).Step = 1);
		yield return new WaitForSeconds(2);
		monsters.Add(mf_bottom.getMonster(Monsters.bt).Step = 2);
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

	public ArrayList MonsterList {
		get {
			return monsters;
		}
	}

}