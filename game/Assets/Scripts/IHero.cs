using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHero {

	int Speed { get; set; }

	void Move();
	void Use();
}
