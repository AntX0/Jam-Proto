using UnityEngine;
using TMPro;

public class HighscoreBoard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _highscoreText;

    private void Start()
    {
        _highscoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    private void Update()
    {
        TryGetComponent(out PlayerScore score);
        if (score.Score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score.Score);
        }
    }
}
