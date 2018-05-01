using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMonster {

	int Health { get; set; }
	float Speed { get; set; }
	int Step { get; set; }

	void Move();
}
