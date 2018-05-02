using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTurtle : MonoBehaviour, IMonster
{

    public static float DEFAULT_SPEED = 1;

    public DifficultyType difficultyType;
    private IHealth iHealth;
    private float speed = DEFAULT_SPEED;
    private int step = 0;
    private MovePattern m;
    public List<MonoBehaviour> observers = new List<MonoBehaviour>();

    public void AddObserver(MonoBehaviour observer)
    {
        Debug.Log("In AddObserver");
        observers.Add(observer);
    }
    // Use this for initialization
    void Start()
    {
        HandleDifficultyType();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ObserveHP();
    }

    private void HandleDifficultyType()
    {

        //To prevent Unity from creating multiple copies of the same component in inspector at runtime
        Component c = gameObject.GetComponent<IHealth>() as Component;

        if (c != null)
        {
            Destroy(c);
        }

        #region Strategy
        switch (difficultyType)
        {

            case DifficultyType.EasyMode:
                iHealth = gameObject.AddComponent<EasyMode>();
                break;

            case DifficultyType.HardMode:
                iHealth = gameObject.AddComponent<HardMode>();
                break;

            default:
                iHealth = gameObject.AddComponent<EasyMode>();
                break;
        }
        #endregion
    }

    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            if (value == DEFAULT_SPEED / 2 || value == DEFAULT_SPEED)
            {
                this.speed = value;
            }
        }
    }

    public int Step
    {
        get
        {
            return step;
        }
        set
        {
            this.step = value;
        }
    }

    public void Move()
    {
        if (m == null)
        {
            m = MovePattern.getInstance();
        }
        else
        {
            m.Move(this);
        }
    }

    public void ObserveHP()
    {
        if (iHealth.Health == 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage()
    {
        iHealth.TakeDamage();
    }

    public void NotifyAll()
    {
        Debug.Log("In NotifyAll");
        foreach (MonoBehaviour observer in observers)
        {
            observer.SendMessage("UpdateState");
        }
    }
}