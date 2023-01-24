using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _invincibilityDurationSeconds;
    [SerializeField] private Canvas _gameOverCanvas;

    private PlayerController _playerController;
    private float _currentHealth;
    private bool _isInvincible = false;
    private Animator _animator;

    public event EventHandler OnDamageTaken;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _gameOverCanvas.enabled = false;
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        if (_isInvincible == true) { _animator.SetTrigger("isHit1"); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Projectile>() && collision.GetComponent<Projectile>().IsEnemyProjectile == true)
        {
            TakeDamage(collision);
            collision.gameObject.SetActive(false);
        }
        else if (collision.GetComponent<GroundScroller>())
        {
            HandleDeath();
        }
        else if (collision.GetComponent<Obstacle>() || collision.GetComponent<EnemyAI>() || collision.GetComponent<Rusher>())
        {
            if (_isInvincible == true) { return; }
            _currentHealth -= 10;
            OnDamageTaken?.Invoke(this, null);
            StartCoroutine(BecomeTemporarilyInvincible());
            CheckHealth();
        }
    }

    private void TakeDamage(Collider2D projectile)
    {
        if (_isInvincible == true) { return; }
        _currentHealth -= projectile.GetComponent<Projectile>().SetDamage();

        OnDamageTaken?.Invoke(this, null);
        CheckHealth();
        StartCoroutine(BecomeTemporarilyInvincible());
    }

    private void CheckHealth()
    {
        if (_currentHealth <= 0)
        {
            HandleDeath();
            _currentHealth = 0;
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

    public void HandleDeath()
    {
        _playerController.enabled = false;
        _gameOverCanvas.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}