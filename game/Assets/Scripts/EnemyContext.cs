using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContext : MonoBehaviour {

    private IEnemy enemy;
    public EnemyContext(IEnemy enemy)
    {
        this.enemy = enemy;
    }

    public void Act()
    {
        enemy.Attack();
        enemy.Move();
    }
}
