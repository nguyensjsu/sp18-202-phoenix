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

    void Start()
    {
        DifficultyLevel diff = DifficultyLevel.GetDifficultyLevelInstance();
        difficultyType = diff == null ? DifficultyType.EasyMode : diff.getDifficulty();
        HandleDifficultyType();
        iHealth.Health = iHealth.Health * 4;
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

    public void AddObserver(MonoBehaviour observer)
    {
        
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
}
