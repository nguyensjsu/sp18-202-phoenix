using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishBehaviour : MonoBehaviour
{

    public Text youLose;
	private readonly int WAIT_TIME = 3;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            BlueTurtle bt = gameObject.GetComponent<BlueTurtle>();
            bt.SendMessage("NotifyAll");
			StartCoroutine(delay());
        }
    }

	private IEnumerator delay()
	{
		youLose.text = "You Lose";
		yield return new WaitForSeconds(WAIT_TIME);
		SceneManager.LoadScene(0);
	}
}