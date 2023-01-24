using System;
using System.Collections;
using UnityEngine;

public class DifficultyController : MonoBehaviour
{
    [SerializeField] private int _difficultyLevel;

    public event EventHandler OnDifficultyIncrease;

    public int DifficultyLevel => _difficultyLevel;

    private void Start()
    {
        StartCoroutine(IncreaseDifficultyLevel());
    }

    private IEnumerator IncreaseDifficultyLevel()
    {
        while (true)
        {
            OnDifficultyIncrease?.Invoke(this, null);
            _difficultyLevel += 1;
            yield return new WaitForSeconds(20);
        }
    }
}
