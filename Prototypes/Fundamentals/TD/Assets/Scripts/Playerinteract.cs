using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerinteract : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PickUp"))
        {
            Debug.Log(other.name);
        }
    }
}
