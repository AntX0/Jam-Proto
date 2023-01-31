using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private int _score;

    private void Start()
    {
        _score = -10; 
        StartCoroutine(IncreaseScore());
    }

    private IEnumerator IncreaseScore()
    {
        while (true)
        {
            _score += 10;
            _scoreText.text = _score.ToString();
            yield return new WaitForSeconds(5);
        }
    }
}
