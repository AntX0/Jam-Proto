using System;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private EnemyScriptableObjject _enemy;

    void Update()
    {
        if (_target == null)
        {
            MoveAway();
            return;
        }
           
        float distanceToTarget = Vector2.Distance(transform.position, _target.position);

        if (distanceToTarget > _enemy.StoppingDistance)
            MoveToTarget();
        else if (distanceToTarget <= _enemy.StoppingDistance)
            _target = null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Projectile>())
        {
            float damage = collision.gameObject.GetComponent<Projectile>().DoDamage();
            if (_enemy.TakeDamage(damage) <= 0)
            {
                Destroy(gameObject);
            }
            
        }
    }

    private void MoveAway()
    {
        transform.Translate(_enemy.Speed * Time.deltaTime * Vector2.left);
    }

    private void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.position, _enemy.Speed * Time.deltaTime);
    }
}
