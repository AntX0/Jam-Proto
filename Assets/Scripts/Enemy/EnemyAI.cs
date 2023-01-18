using System;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private EnemyScriptableObjject _enemy;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveToTarget();
        /*LookAtTarget();*/
    }

    private void LookAtTarget()
    {
        
    }

    private void MoveToTarget()
    {
        float distanceToTarget = Vector2.Distance(transform.position, _target.position);

        if (distanceToTarget > _enemy.StoppingDistance)
            transform.position = Vector2.MoveTowards(transform.position, _target.position, _enemy.Speed * Time.deltaTime);
        else if (distanceToTarget <= _enemy.StoppingDistance)
            transform.position = Vector2.MoveTowards(transform.position, _target.position, -_enemy.Speed * Time.deltaTime);
    }
}
