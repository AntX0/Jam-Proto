using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    [SerializeField] private int _difficultyLevel;

    private void OnEnable()
    {
        DifficultyController.OnDifficultyIncrease += CheckDifficulty;
    }

    private void OnDisable()
    {
        DifficultyController.OnDifficultyIncrease -= CheckDifficulty;
    }

    private void CheckDifficulty()
    {
        if (DifficultyController.DifficultyLevel >= _difficultyLevel)
        {
            GetComponent<ObstacleCreator>().enabled = true;
        }
    }
}
