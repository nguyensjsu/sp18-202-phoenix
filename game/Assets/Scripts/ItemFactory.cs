using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : MonoBehaviour
{

	public static IItem getItem(Items item, Vector3 coordinate){
		GameObject i = Instantiate(Resources.Load(item.ToString()), coordinate, Quaternion.identity) as GameObject;
		Destroy (i, i.GetComponent<IItem>().TTL);
		return i.GetComponent<IItem>();
	}
}

public enum Items {
	bomb,
	bullet,
	coin,
	fire,
	pow
};


