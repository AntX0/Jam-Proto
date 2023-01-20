using System;
using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private EnemyScriptableObjject _enemy;
    [SerializeField] private GameObject _projectilePrefab;

    private void Start()
    {
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
        if (collision.gameObject.GetComponent<Projectile>())
        {
            Destroy(collision.gameObject);
            float damage = collision.gameObject.GetComponent<Projectile>().DoDamage();
            if (_enemy.TakeDamage(damage) <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private IEnumerator AttackTarget()
    {
        while(_target != null)
        {
            Vector2 direction = _target.position - transform.position;

            GameObject projectile = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
            Projectile projectileStats = projectile.GetComponent<Projectile>();
            Rigidbody2D rigidbody = projectile.GetComponent<Rigidbody2D>();

            rigidbody.AddForce(direction * projectileStats.Speed);
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
