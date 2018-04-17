using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameSystem : MonoBehaviour {

	abstract public void Initialize();
	abstract public void Play();
	abstract public void End();

	public ArrayList monsters;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void Run(){
		Initialize();
		Play ();
		End ();
	}

	public bool ToggleGamePause() {
		if (Time.timeScale == 0) {
			Time.timeScale = 1;
			return false;
		} 
		Time.timeScale = 0;
		return true;
	}

}
