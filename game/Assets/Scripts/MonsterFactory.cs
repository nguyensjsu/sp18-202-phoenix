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
		GameObject m = Instantiate(Resources.Load(monster.ToString()), startingPoint, Quaternion.identity) as GameObject;
		return m.GetComponent<IMonster> ();
	}
}

public enum Monsters {
	bt,
    rt,
    goomba,
	Mario,
	Luigi
};


