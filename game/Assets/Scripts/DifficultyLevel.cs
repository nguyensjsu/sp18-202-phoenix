using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyLevel : MonoBehaviour
{

    private static DifficultyLevel difficultyLevelInstance = null;
    private static DifficultyType difficulty;

    public DifficultyType getDifficulty()
    {
        return difficulty;
    }

    public void setDifficulty(DifficultyType value)
    {
        difficulty = value;
    }

    static DifficultyLevel()
    {
        difficulty = DifficultyType.EasyMode;
    }

    public static DifficultyLevel NewDifficultyLevelInstance()
    {
        difficultyLevelInstance = new DifficultyLevel();
        return difficultyLevelInstance;
    }

    public static DifficultyLevel GetDifficultyLevelInstance()
    {
        return difficultyLevelInstance;
    }

}
