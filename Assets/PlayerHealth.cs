using System;
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
        else if (collision.GetComponent<EnemyAI>())
        {
            _currentHealth -= 10;
        }
    }

    private void TakeDamage(Collider2D projectile)
    {
        _currentHealth -= projectile.GetComponent<Projectile>().DoDamage();

        if (_currentHealth <= 0)
        {
            _currentHealth= 0;
            _playerController.enabled = false;
        }
    }
}
