using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {

}

public interface IHealth
{
    int Health { get; set; }
    void TakeDamage();
}
public class EasyMode : MonoBehaviour, IHealth
{
    private int health = 6;

    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            this.health = value;
        }
    }

    public void TakeDamage()
    {
        this.Health -= 2;
    }
}
public class HardMode : MonoBehaviour, IHealth
{
    private int health = 10;

    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            this.health = value;
        }
    }

    public void TakeDamage()
    {
        this.Health -= 1;
    }
}
