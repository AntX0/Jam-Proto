using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _numberOfHearts;
    [SerializeField] private Image[] _hearts;
    [SerializeField] private Sprite _heartSprite;

    private void Start()
    {
        GetComponent<PlayerHealth>().OnDamageTaken += (sender, args) => _numberOfHearts -= 1;   
    }

    private void Update()
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
