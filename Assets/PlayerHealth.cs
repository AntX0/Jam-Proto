using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private PlayerController _playerController;
    [SerializeField] private float _currentHealth;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        
    }
    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Projectile>() && collision.GetComponent<Projectile>().IsHitPlayer == true)
        {
            TakeDamage(collision);
            Destroy(collision.gameObject);
        }
        else if (collision.GetComponent<GroundScroller>())
        {
            _playerController.enabled = false;
        }
        else if (collision.GetComponent<Obstacle>())
        {
            _currentHealth -= 10;
            CheckHealth();
        }
    }

    private void TakeDamage(Collider2D projectile)
    {
        _currentHealth -= projectile.GetComponent<Projectile>().DoDamage();

        CheckHealth();
    }

    private void CheckHealth()
    {
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            _playerController.enabled = false;
        }
    }
}
