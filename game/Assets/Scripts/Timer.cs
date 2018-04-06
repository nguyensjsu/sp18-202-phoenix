using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Text timerText;
	private float startTime;

	// Use this for initialization
	void Start () {
		// timer will start as soon as we enter game mode
		startTime = Time.time;
		
	}
	
	// Update is called once per frame
	void Update () {
		float time = Time.time - startTime;
		string minutes = ((int) time / 60).ToString();
		string seconds = (time % 60).ToString("00");

		timerText.text = "Time " + string.Format("{0:00}:{1:00}", minutes, seconds);
	}
}
