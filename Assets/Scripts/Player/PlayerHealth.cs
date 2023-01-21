using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _invincibilityDurationSeconds;

    private PlayerController _playerController;
    [SerializeField] private float _currentHealth;
    private bool _isInvincible = false;
    private Animator _animator;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _animator = GetComponent<Animator>();
    }
    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        if (_isInvincible == true) { _animator.SetTrigger("isHit1");}
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
            StartCoroutine(BecomeTemporarilyInvincible());
            CheckHealth();
        }
    }

    private void TakeDamage(Collider2D projectile)
    {
        if (_isInvincible == true) {  return; }
        _currentHealth -= projectile.GetComponent<Projectile>().SetDamage();

        CheckHealth();
        StartCoroutine(BecomeTemporarilyInvincible());

    }

    private void CheckHealth()
    {
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            _playerController.enabled = false;
        }
    }

    private IEnumerator BecomeTemporarilyInvincible()
    {
        Debug.Log("Player turned invincible!");
        _isInvincible = true;

        yield return new WaitForSeconds(_invincibilityDurationSeconds);

        
        _isInvincible = false;
        Debug.Log("Player is no longer invincible!");
    }

}
