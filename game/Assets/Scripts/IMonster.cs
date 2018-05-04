using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMonster {

	float Speed { get; set; }
	int Step { get; set; }
	int Route { get; set; }

	void Move();
    void AddObserver(MonoBehaviour observer);
    void ObserveHP();
    void TakeDamage();
}
