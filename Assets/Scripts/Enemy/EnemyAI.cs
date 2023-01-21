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

    private void Awake()
    {
        _enemyAnimationHandler = GetComponent<EnemyAnimationHandler>();
        _currentHealth = _enemy.Health;
    }

    private void Start()
    {
        _target = FindObjectOfType<Target>().transform;
        StartCoroutine(AttackTarget());
    }

    void Update()
    {
        if (_target == null)
        {
            MoveAway();
            return;
        }
           
        float distanceToTarget = Vector2.Distance(transform.position, _target.position);

        if (distanceToTarget > _enemy.StoppingDistance)
        {
            MoveToTarget();
        } 
        else if (distanceToTarget <= _enemy.StoppingDistance)
        {
            _target = null;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        ApplyDamage(collision);
    }

    private void ApplyDamage(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Projectile>())
        {
            Destroy(collision.gameObject);

            float damage = collision.gameObject.GetComponent<Projectile>().DoDamage();
            float newHealth = _currentHealth -= damage;

            if (newHealth <= 0)
            {
                _currentHealth = 0;
                Destroy(gameObject);
            }
        }
    }

    private IEnumerator AttackTarget()
    {
        while(_target != null)
        {
            _enemyAnimationHandler.PlayAttackAnimation();

            Vector2 direction = _target.position - transform.position;

            GameObject projectile = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
            Projectile projectileStats = projectile.GetComponent<Projectile>();
            Rigidbody2D rigidbody = projectile.GetComponent<Rigidbody2D>();

            rigidbody.AddRelativeForce(direction * projectileStats.Speed, ForceMode2D.Force);
            yield return new WaitForSeconds(_enemy.SecondsBetweenShots);
        }
    }

    private void MoveAway()
    {
        transform.Translate(_enemy.Speed * 2 * Time.deltaTime * Vector2.left);
    }

    private void MoveToTarget()
    {
        transform.Translate(_enemy.Speed * Time.deltaTime * Vector2.left);
        /*transform.position = Vector2.MoveTowards(transform.position, _target.position, _enemy.Speed * Time.deltaTime);*/
    }
}
