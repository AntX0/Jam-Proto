using UnityEditor;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private ProjectileScriptableObject _projectile;
    [SerializeField] private bool _isHitPlayer;

    private Rigidbody2D _rigidbody2D;
    private float _speed;

    public float Speed => _speed;
    public bool IsHitPlayer => _isHitPlayer;

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
