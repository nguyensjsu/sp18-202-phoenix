using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

	Animator animator;
	string lastState;

	float vertExtent;
	float horzExtent;

	float step = 0.05f;
	float offsetX = 0.45f;
	float offsetY = 0.5f;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();

		vertExtent = (Camera.main.orthographicSize) - offsetY;    
		horzExtent = (Camera.main.orthographicSize * Screen.width / Screen.height) - offsetX;
	}
	
	// Update is called once per frame
	void Update () {
		string state = null;

		if (Input.GetKey ("left")) {
			Vector3 position = this.transform.position;
			position.x -= step;
			if (position.x > -horzExtent) {
				this.transform.position = position;
			}

			if (!Input.GetKey ("right")) {
				state = "move_left";
				animator.Play (state);
			}
		}
		if (Input.GetKey ("right")) {
			Vector3 position = this.transform.position;
			position.x += step;
			if (position.x < horzExtent) {
				this.transform.position = position;
			}

			if (!Input.GetKey ("left")) {
				state = "move_right";
				animator.Play (state);
			}
		}
		if (Input.GetKey ("up")) {
			Vector3 position = this.transform.position;
			position.y += step;
			if (position.y < vertExtent) {
				this.transform.position = position;
			}
				
			if (!Input.GetKey ("right") && !Input.GetKey ("left") && !Input.GetKey ("down")) {
				state = "move_up";
				animator.Play (state);
			}
		}
		if (Input.GetKey ("down")) {
			Vector3 position = this.transform.position;
			position.y -= step;
			if (position.y > -vertExtent) {
				this.transform.position = position;
			}
				
			if (!Input.GetKey ("right") && !Input.GetKey ("left") && !Input.GetKey ("up")) {
				state = "move_down";
				animator.Play (state);
			}
		}
			
		if (state == null) {
			animator.Play ("idle_" + lastState);
		}
		lastState = state;
	}
}
