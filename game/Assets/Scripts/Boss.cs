using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boss : MonoBehaviour, IMonster {

	public static float DEFAULT_SPEED = 1;
    public DifficultyType difficultyType;
    private IHealth iHealth;
    protected float speed;
	protected int step = 0;
	protected int route = 0;
	protected bool win;
    protected List<MonoBehaviour> observers = new List<MonoBehaviour>();

    void Start() {
        DifficultyLevel diff = DifficultyLevel.GetDifficultyLevelInstance();

        if (diff.getDifficulty() == DifficultyType.EasyMode)
            difficultyType = DifficultyType.EasyMode;
        else
            difficultyType = DifficultyType.HardMode;

        HandleDifficultyType();
        iHealth.Health = iHealth.Health * 4;
    }

    public void HandleDifficultyType() {

        //To prevent Unity from creating multiple copies of the same component in inspector at runtime
        Component c = gameObject.GetComponent<IHealth>() as Component;

        if (c != null) {
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

    public void AddObserver(MonoBehaviour observer) {
        observers.Add(observer);
    }

    public float Speed { 
		get { return speed; }
		set { this.speed = value; }
	}

	public int Step {
		get { return step; }
		set { this.step = value; }
	}

	public int Route {
		get { return route; }
		set { this.route = value; }
	}

	public abstract void Move();

    public void ObserveHP()
    {
        if (iHealth.Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }


    public void TakeDamage() {
        iHealth.TakeDamage();
    }

    public void OnDestroy() {
        try
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameSystem>().SendMessage("DecreaseNumberOfMonsters");
        }
        catch
        { }
    }

    public void NotifyAll()
    {
        // bosses don't cross the finish line
    }
}
