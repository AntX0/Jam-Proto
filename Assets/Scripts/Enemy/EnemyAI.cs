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
    private bool _allowFire;
    private float _time;

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
        float distanceToTarget = Vector2.Distance(transform.position, _target.position);

        if (distanceToTarget > _enemy.StoppingDistance && _time >= nextTimeToFire)
        {
            _time = 0;
            DoFire();
        }
        else if (distanceToTarget <= _enemy.StoppingDistance)
        {
            _target = null;
        }
    }

    private void DoFire()
    {
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
                Destroy(gameObject);
            }
        }
    }
}
