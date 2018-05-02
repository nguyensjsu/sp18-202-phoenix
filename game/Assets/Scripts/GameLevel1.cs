using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameLevel1 : GameSystem, IGameSystem {

	// change game level here
	private static int LEVEL = 1;

	void Start () {
		Run ();
	}

	void Update () {
		ObservePauseButton ();
		ObserveMonsters ();
	}

	public override void Initialize(){
		Init ();
		startingCoordinates.Add (new Vector3 (-11.5f, 0.4f, 1));	// starting coordinate for enemies
//		startingCoordinates.Add (new Vector3 (x, y, 1));			// you can add more starting coordinate based on the routes on your map
//		startingCoordinates.Add (new Vector3 (x, y, 1));			// monster factory will be generated based on the number of starting coordinates
		MovePattern.setInstance(LEVEL);
		ig = new ItemGenerator (0.8f); // items spawn rate
		SetUp();
	}

	public override void Play(){
		timer.Run ();
		StartCoroutine (Spawn());
		StartCoroutine (ig.Generate ());
	}

	// how the enemies will be spawned, use enum "Monsters" to select the enemy you want to spawn
	public IEnumerator Spawn() {
		// choose which monster factory you want to spawn the monster
		// the number of monster factories in "mfs" variable is equal to the number of starting coordinates
		monsters.Add(mfs[0].getMonster(Monsters.bt));
		yield return new WaitForSeconds(2);
		monsters.Add(mfs[0].getMonster(Monsters.bt));
		yield return new WaitForSeconds(2);
		monsters.Add(mfs[0].getMonster(Monsters.bt));
		yield return new WaitForSeconds(8);
		monsters.Add(mfs[0].getMonster(Monsters.bt));
		yield return new WaitForSeconds(2);
		monsters.Add(mfs[0].getMonster(Monsters.bt));
		yield return new WaitForSeconds(2);
		monsters.Add(mfs[0].getMonster(Monsters.bt));

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