using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private ProjectileScriptableObject _projectile;
    [SerializeField] private bool _isEnemyProjectile;

    private float _speed;
    private Vector2 _direction;
    private Vector2 _startPosition;

    public float Speed => _speed;
    public bool IsEnemyProjectile => _isEnemyProjectile;

    private void Awake()
    {
        _speed = _projectile.Speed;
    }

    private void Start()
    {
        _startPosition = transform.position;
        if (_isEnemyProjectile) { _direction = Vector2.left; }
        else { _direction = Vector2.right; }
    }

    private void Update()
    {
        DisableByDistance();
        TranslateProjectileTowards(_direction);
    }

    private void TranslateProjectileTowards(Vector2 direction)
    {
        transform.Translate(_projectile.Speed * Time.deltaTime * direction);
    }

    private void DisableByDistance()
    {
        float distance = Vector2.Distance(_startPosition, transform.position);

        if (distance > _projectile.FlyDistance)
        {
            gameObject.SetActive(false);
        }
    } 

    public float SetDamage()
    {
        return _projectile.Damage;
    }
}
