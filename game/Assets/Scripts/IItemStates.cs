using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemStates {

	void waiting();
	void idle();
	void executing();
}
