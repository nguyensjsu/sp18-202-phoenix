using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour {

    public Text loseText;
    Animator animator;
	string lastState;
	private string direction;

	float vertExtent;
	float horzExtent;

	public float step = 0.05f;
	float offsetX = 0.45f;
	float offsetY = 0.5f;

	void Awake() {
		lastState = "idle_move_down";
	}
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
//        loseText.text = "";
		vertExtent = (Camera.main.orthographicSize) - offsetY;    
		horzExtent = (Camera.main.orthographicSize * Screen.width / Screen.height) - offsetX;
	}
	
	// Update is called once per frame
	void Update () {
		string state = null;
		if (Time.timeScale == 1) {
			if (Input.GetKey ("up")) {
				Vector3 position = this.transform.position;
				position.y += step;
				if (position.y < vertExtent) {
					this.transform.position = position;
				}
					
				direction = "up";

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

				direction = "down";

				if (!Input.GetKey ("right") && !Input.GetKey ("left") && !Input.GetKey ("up")) {
					state = "move_down";
					animator.Play (state);
				}
			}
			if (Input.GetKey ("left")) {
				Vector3 position = this.transform.position;
				position.x -= step;
				if (position.x > -horzExtent) {
					this.transform.position = position;
				}

				direction = "left";

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

				direction = "right";

				if (!Input.GetKey ("left")) {
					state = "move_right";
					animator.Play (state);
				}
			}

			if (state == null) {
				animator.Play("idle_" + lastState);
			} else {
				lastState = state;
			}
		}
	}

	// TODO: Fix player rotation when colliding with object
	void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.CompareTag("Item"))
        {
            //Destroy (coll.gameObject);
            coll.gameObject.SetActive(false);
        }
        else if (coll.gameObject.CompareTag("enemy"))
        {
            gameObject.SetActive(false);
            loseText.text = "You Lose";
        }
	}

	public string getDirection() {
		return direction;
	}
}
