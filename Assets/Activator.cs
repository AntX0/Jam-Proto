using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    [SerializeField] private DifficultyController _difficultyController;

    private void Start()
    {
        _difficultyController.OnDifficultyIncrease += (sender, args) =>
        {
            Debug.Log(_difficultyController.DifficultyLevel);
            CheckDifficulty();
        };
    }

    private void Update()
    {
        Debug.Log(_difficultyController.DifficultyLevel);
    }

    private void CheckDifficulty()
    {
        if (_difficultyController.DifficultyLevel >= 1)
        {
            GetComponent<ObstacleCreator>().enabled = true;
        }
    }
}
