using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private EnemyScriptableObjject _enemy;
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private EnemyBrain _enemyBrain;

    private EnemyAnimationHandler _enemyAnimationHandler;
    private float _currentHealth;
    private ObjectPooler _objectPooler;
    private float _time;

    public Vector2 _directionToTarget;

    public Transform Target => _target;

    private void Awake()
    {
        _enemyAnimationHandler = GetComponent<EnemyAnimationHandler>();
        _currentHealth = _enemy.Health;
    }

    private void Start()
    {
        _objectPooler = GetComponent<ObjectPooler>();
        _target = FindObjectOfType<Target>().transform;
        _time = _enemy.FireRate;
    }

    private void Update()
    {
        _time += Time.deltaTime;
        float nextTimeToFire = 1 / _enemy.FireRate;
        float distanceToTarget = Vector2.Distance(transform.position, _target.position.normalized);
        _directionToTarget = _target.position - transform.position;

        _enemyBrain.Move(this);

        if (distanceToTarget > _enemy.StoppingDistance && _time >= nextTimeToFire)
        {
            _time = 0;
            DoFire();
        }
        else if (distanceToTarget <= _enemy.StoppingDistance)
        {
            MoveAway();
        }
    }

    private void FixedUpdate()
    {
        if (transform.position.x <= -5)
        {
            ProcessResurection();
        }
    }

    private void ProcessResurection()
    {
        _currentHealth = _enemy.Health;
        gameObject.SetActive(false);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void DoFire()
    {
        _enemyAnimationHandler.PlayAttackAnimation();
        _objectPooler.SpawnObject();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ApplyDamage(collision);
    }

    private void ApplyDamage(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Projectile projectile))
        {
            _enemyAnimationHandler.PlayHitAnimation();
            projectile.gameObject.SetActive(false);

            float damage = projectile.SetDamage();
            float newHealth = _currentHealth -= damage;

            if (newHealth <= 0)
            {
                ProcessResurection();
            }
        }
    }

    private void MoveAway()
    {
        transform.Translate(_enemy.Speed * 2f * Time.deltaTime * Vector2.left);
    }
}
