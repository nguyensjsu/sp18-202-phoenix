using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour {

    public bool inventoried;
	public void DoAction()
    {
        gameObject.SetActive(false);
    }
}
