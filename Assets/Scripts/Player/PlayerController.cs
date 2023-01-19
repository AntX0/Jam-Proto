using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _forceAmmountToAdd = 10f;
    [SerializeField] private float _boundY;
    [SerializeField] private ProjectileScriptableObject _projectile;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();  
    }

    private void Update()
    {
        AddForceTowardsSky();
    }

    private void AddForceTowardsSky()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _rigidbody.position.y < _boundY)
        {
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.AddForce(Vector2.up * _forceAmmountToAdd);

            GameObject instance = SpawnProjectile();
            ShootProjectile(instance);
        }
    }

    private GameObject SpawnProjectile()
    {
        return Instantiate(_projectile.ProjectilePrefab, transform.position, Quaternion.Euler(0,0,-90));
    }

    private void ShootProjectile(GameObject projectile)
    {
       var rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.right * _projectile.Speed);
    }
}
