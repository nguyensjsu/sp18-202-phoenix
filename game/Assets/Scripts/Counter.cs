using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Counter : MonoBehaviour
{
    // Use this for initialization

    private PlayerInteract playerInteract;
    private Text numberOfBombs;
    private Text numberOfFlowers;

	void Start()
	{
        playerInteract = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteract>();
        numberOfBombs = GameObject.FindGameObjectWithTag("MainCanvas").transform.Find("Bomb").GetComponent<Text>();
        numberOfFlowers = GameObject.FindGameObjectWithTag("MainCanvas").transform.Find("Flower").GetComponent<Text>();
	}

	// Update is called once per frame
	void Update()
	{
        numberOfBombs.text = "Bomb: " + playerInteract.numberOfBombs.ToString();
        numberOfFlowers.text = "Flower: " + playerInteract.numberOfFireBalls.ToString();	
	}
}
