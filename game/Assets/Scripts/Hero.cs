using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour {

	private static readonly int WAIT_TIME = 5;
    public Text loseText;
    Animator animator;
	string lastState;
	private string direction;

	float vertExtent;
	float horzExtent;

	public float step = 0.05f;
	float offsetX = 0.45f;
	float offsetY = 0.5f;
	private bool alive;

	void Awake() {
		lastState = "move_down";
		direction = "down";
		alive = true;
	}

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		vertExtent = (Camera.main.orthographicSize) - offsetY;    
		horzExtent = (Camera.main.orthographicSize * Screen.width / Screen.height) - offsetX;
	}
	
	// Update is called once per frame
	void Update () {
		if (alive) {
			string state = null;
			if (Time.timeScale == 1) {
				if (Input.GetKey("up")) {
					Vector3 position = this.transform.position;
					position.y += step;
					if (position.y < vertExtent) {
						this.transform.position = position;
					}

					direction = "up";

					if (!Input.GetKey("right") && !Input.GetKey("left") && !Input.GetKey("down")) {
						state = "move_up";
						animator.Play(state);
					}
				}
				if (Input.GetKey("down")) {
					Vector3 position = this.transform.position;
					position.y -= step;
					if (position.y > -vertExtent) {
						this.transform.position = position;
					}

					direction = "down";

					if (!Input.GetKey("right") && !Input.GetKey("left") && !Input.GetKey("up")) {
						state = "move_down";
						animator.Play(state);
					}
				}
				if (Input.GetKey("left")) {
					Vector3 position = this.transform.position;
					position.x -= step;
					if (position.x > -horzExtent) {
						this.transform.position = position;
					}

					direction = "left";

					if (!Input.GetKey("right")) {
						state = "move_left";
						animator.Play(state);
					}
				}
				if (Input.GetKey("right")) {
					Vector3 position = this.transform.position;
					position.x += step;
					if (position.x < horzExtent) {
						this.transform.position = position;
					}

					direction = "right";

					if (!Input.GetKey("left")) {
						state = "move_right";
						animator.Play(state);
					}
				}

				if (state == null) {
					animator.Play("idle_" + lastState);
				} else {
					lastState = state;
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.CompareTag("Item")) {
			coll.gameObject.SetActive(false);
			return;
		} else if (coll.gameObject.CompareTag("enemy") ||
				   coll.gameObject.CompareTag("boss") || coll.gameObject.CompareTag("enemy_rt") || coll.gameObject.CompareTag("enemy_goomba")) {
			alive = false;
			loseText.text = "You Lose";
			StartCoroutine(lose());
		}
	}

	public string getDirection() {
		return direction;
	}

	private IEnumerator lose()
	{
		if (direction.Equals("left"))
			animator.Play("die_left");
		else
			animator.Play("die_right");

        // setting time scale so small that it appears that it is paused
        Time.timeScale = .0000001f;
        yield return new WaitForSeconds(WAIT_TIME * .0000001f);
		SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

}
