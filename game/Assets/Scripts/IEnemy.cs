using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{

    int Health { get; set; }
    int Speed { get; set; }
    int Step { get; set; }

    void Move();
    void Attack();
}
