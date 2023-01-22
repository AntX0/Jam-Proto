using System;
using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private EnemyScriptableObjject _enemy;
    [SerializeField] private GameObject _projectilePrefab;

    private EnemyAnimationHandler _enemyAnimationHandler;
    private float _currentHealth;
    private ObjectPooler _objectPooler;
    private float _time;
    public Vector2 _directionToTarget;

    private void Awake()
    {
        _enemyAnimationHandler = GetComponent<EnemyAnimationHandler>();
        _currentHealth = _enemy.Health;
    }

    private void Start()
    {
        _objectPooler = GetComponent<ObjectPooler>();
        _target = FindObjectOfType<Target>().transform;
        _time = _enemy.FireRate;
    }

    void Update()
    {
        _time += Time.deltaTime;
        float nextTimeToFire = 1 / _enemy.FireRate;
        float distanceToTarget = Vector2.Distance(transform.position, _target.position.normalized);
        _directionToTarget = _target.position - transform.position;
        MoveObject();
        if (distanceToTarget > _enemy.StoppingDistance && _time >= nextTimeToFire)
        {
            _time = 0;
            DoFire();
        }
        else if (distanceToTarget <= _enemy.StoppingDistance)
        {
            MoveAway();
        }
    }

    private void DoFire()
    {
        _enemyAnimationHandler.PlayAttackAnimation();
        _objectPooler.SpawnObject();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        ApplyDamage(collision);
    }

    private void ApplyDamage(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Projectile>())
        {
            collision.gameObject.SetActive(false);

            float damage = collision.gameObject.GetComponent<Projectile>().SetDamage();
            float newHealth = _currentHealth -= damage;

            if (newHealth <= 0)
            {
                _currentHealth = 0;
                gameObject.SetActive(false);
            }
        }
    }

    private void MoveAway()
    {
        transform.Translate(_enemy.Speed * 2 * Time.deltaTime * Vector2.left);
    }

    private void MoveObject()
    {
        transform.Translate(_enemy.Speed * Time.deltaTime * Vector2.left);
    }
}
