using System;
using System.Collections;
using UnityEngine;

public class DifficultyController : MonoBehaviour
{
    [SerializeField] private static int _difficultyLevel;

    public static event Action OnDifficultyIncrease;

    public static int DifficultyLevel => _difficultyLevel;

    private void Start()
    {
        _difficultyLevel = 0;
        StartCoroutine(IncreaseDifficultyLevel());
    }

    private IEnumerator IncreaseDifficultyLevel()
    {
        while (true)
        {
            OnDifficultyIncrease?.Invoke();
            _difficultyLevel += 1;
            yield return new WaitForSeconds(20);
        }
    }
}
