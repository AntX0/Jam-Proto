using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private ProjectileScriptableObject _projectile;

    private Rigidbody2D _rigidbody2D;
    private float _speed;

    private void Awake()
    {
        _projectile = GetComponent<ProjectileScriptableObject>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _rigidbody2D.mass = _projectile.Mass;
        _speed = _projectile.Speed;
    }
}
