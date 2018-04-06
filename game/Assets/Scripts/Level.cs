using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour {

	public Text levelText;

	// Use this for initialization
	void Start () {
		// level is set to the scene name
		levelText.text = Application.loadedLevelName.ToString();
	}
}
