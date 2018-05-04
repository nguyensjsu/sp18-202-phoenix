using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishBehaviour_goomba : MonoBehaviour
{

    public Text youLose;
    GameObject canvasObj;
    Transform textTr;
    private static readonly int WAIT_TIME = 3;

    private void Awake()
    {
        canvasObj = GameObject.FindGameObjectWithTag("MainCanvas");
        textTr = canvasObj.transform.Find("Lose Text");
        youLose = textTr.GetComponent<Text>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            if (collision.gameObject.CompareTag("Finish"))
            {
                Goomba goomba = gameObject.GetComponent<Goomba>();
                goomba.SendMessage("NotifyAll");
                StartCoroutine(lose());
            }
        }
        catch { }
    }

    private IEnumerator lose()
    {
        youLose.text = "You Lose";
        Time.timeScale = 0;
        yield return new WaitForSeconds(WAIT_TIME);
        SceneManager.LoadScene(0);
    }
}