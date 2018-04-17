using System;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFactory : MonoBehaviour
{
	private Vector3 startingPoint;

	public MonsterFactory(Vector3 startingPoint) {
		this.startingPoint = startingPoint;
	}

	public IMonster getMonster(Monsters monster){
		if(monster == Monsters.bt){
			GameObject m = Instantiate(Resources.Load("bt"), startingPoint, Quaternion.identity) as GameObject;
			return m.GetComponent<IMonster> ();
		} 

		return null;
	}
}

public enum Monsters {
	bt
};


