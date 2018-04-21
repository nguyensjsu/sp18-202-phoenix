using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb2d;
    public float speed;
    private int count;
    private int item_count = 0;
    public Text textCount;
    public Text WinText;
    public GameObject item;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        WinText.text = "";
        SetCountText();
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown("space"))
        {
            item_count += 1;
        }
            
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            item_count += 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("monster"))
        {
            gameObject.SetActive(false);
            WinText.text = "You lose";
        }
    }

    void SetCountText()
    {
        textCount.text = "Count:" + count.ToString();
        if (count >= 3)
            WinText.text = "You Win";
    }

    void SetItemCountText()
    {
        
    }
}
