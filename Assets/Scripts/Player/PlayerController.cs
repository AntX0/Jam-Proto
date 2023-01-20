using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _forceAmmountToAdd = 10f;
    [SerializeField] private float _boundY;
    [SerializeField] private GameObject _projectilePrefab;

    private Rigidbody2D _rigidbody;
    private BirdAnimationHandler _birdAnimationHandler;
    private Projectile _projectile;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _birdAnimationHandler = GetComponent<BirdAnimationHandler>();
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
            _birdAnimationHandler.PlayLeapAnimation();

            GameObject instance = SpawnProjectile();
            ShootProjectile(instance);
            Destroy(instance, 5f);
        }
    }

    private GameObject SpawnProjectile()
    {
        return Instantiate(_projectilePrefab, transform.position, Quaternion.Euler(0, 0, 0));
    }

    private void ShootProjectile(GameObject instance)
    {
        Rigidbody2D rigidBody = instance.GetComponent<Rigidbody2D>();
        Projectile projectile = instance.GetComponent<Projectile>();
        rigidBody.AddForce(Vector2.right * projectile.Speed);
        Debug.Log(projectile.Speed);
    }
}
