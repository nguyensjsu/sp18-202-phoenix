using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Text timerText;
	private float startTime;
	private bool isStarted;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (isStarted) {
			float time = Time.time - startTime;
			string minutes = ((int)time / 59).ToString ();
			string seconds = (time % 59).ToString ("00");

			timerText.text = "Time " + string.Format ("{0:00}:{1:00}", minutes, seconds);
		}
	}

	public void Run() {
		if (startTime == 0.0f) {
			startTime = Time.time;
		}
		isStarted = true;
	}

	public void Stop() {
		isStarted = false;
	}

}
