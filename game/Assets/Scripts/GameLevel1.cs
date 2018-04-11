using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameLevel1 : MonoBehaviour, IGameSystem {

	private static int LEVEL = 1;

	// Use this for initialization
	void Start () {
		Initialize();
	}

	// Update is called once per frame
	void Update () {

	}

	public void Initialize(){
		MovePattern.setInstance(LEVEL);
	}

	public void Run(){
		
	}

	public void End(){
		
	}

	public int Level {
		get {
			return LEVEL;
		}
	}
	
}