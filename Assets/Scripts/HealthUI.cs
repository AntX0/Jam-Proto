using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _numberOfHearts;
    [SerializeField] private Image[] _hearts;
    [SerializeField] private Sprite _heartSprite;

    private void OnEnable()
    {
        PlayerHealth.OnDamageTaken += DecreaseHeartsAmount;
        PlayerHealth.OnDamageTaken += UpdateHeartsAmount;
    }

    private void OnDisable()
    {
        PlayerHealth.OnDamageTaken -= DecreaseHeartsAmount;
        PlayerHealth.OnDamageTaken -= UpdateHeartsAmount;
    }

    private void Start()
    {
        UpdateHeartsAmount();
    }

    private void DecreaseHeartsAmount() 
    { 
        _numberOfHearts -= 1;
    }

    private void UpdateHeartsAmount()
    {
        for (int i = 0; i < _hearts.Length; i++)
        {
            if (i < _numberOfHearts)
            {
                _hearts[i].enabled = true;
            }
            else
            {
                _hearts[i].enabled = false;
            }
        }
    }
}
