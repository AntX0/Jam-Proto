using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rusher : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private EnemyScriptableObjject _enemy;
    
    private EnemyAnimationHandler _enemyAnimationHandler;
    private float _currentHealth;
    public Vector2 _directionToTarget;

    private void Awake()
    {
        _enemyAnimationHandler = GetComponent<EnemyAnimationHandler>();
        _currentHealth = _enemy.Health;
    }

    private void Start()
    {
        FindObjectOfType<ObjectDestroyer>().OnCollison += (sender, args) => _currentHealth = _enemy.Health;
        _target = FindObjectOfType<Target>().transform;
    }

    private void Update()
    {
        _directionToTarget= _target.position - transform.position;
        float distanceToTarget = Vector2.Distance(transform.position, _target.position.normalized);
        if (distanceToTarget > _enemy.StoppingDistance)
        {
            MoveTowardsTarget();
        }
        else if (distanceToTarget <= _enemy.StoppingDistance)
        {
            transform.Translate(_enemy.Speed * 2 * Time.deltaTime * Vector2.left);
        }
    }

    private void MoveTowardsTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.position, _enemy.Speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ApplyDamage(collision);
    }

    private void ApplyDamage(Collision2D collision)
    {
        _enemyAnimationHandler.PlayHitAnimation();
        if (collision.gameObject.GetComponent<Projectile>())
        {
            collision.gameObject.SetActive(false);

            float damage = collision.gameObject.GetComponent<Projectile>().SetDamage();
            float newHealth = _currentHealth -= damage;

            if (newHealth <= 0)
            {
                gameObject.SetActive(false);
                _currentHealth = _enemy.Health;
            }
        }
    }
}
