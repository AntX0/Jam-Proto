using UnityEditor;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private ProjectileScriptableObject _projectile;

    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed;

    public float Speed => _speed;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _speed = _projectile.Speed;
    }

    private void Start()
    {
        _rigidbody2D.mass = _projectile.Mass;
    }

    public float DoDamage()
    {
        return _projectile.Damage;
    }
}
