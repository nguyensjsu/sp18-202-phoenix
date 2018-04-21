using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour {

    public bool inventoried;
    public string type;
	public void DoAction()
    {
        gameObject.SetActive(false);
    }
    public void DoAnotherAction(float x, float y, float z)
    {
        gameObject.transform.position = new Vector3(x, y, z);
        gameObject.SetActive(true);
    }
}
