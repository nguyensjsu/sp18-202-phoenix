using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishBehaviour : MonoBehaviour
{

    public Text youLose;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            BlueTurtle bt = gameObject.GetComponent<BlueTurtle>();
            bt.SendMessage("NotifyAll");
            youLose.text = "You Lose";
        }
    }
}