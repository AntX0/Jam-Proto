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

    private void OnEnable()
    {
        ObjectDestroyer.OnCollison += (sender, args) => _currentHealth = _enemy.Health;
    }

    private void OnDisable()
    {
        ObjectDestroyer.OnCollison -= (sender, args) => _currentHealth = _enemy.Health;
    }

    private void Start()
    {
        _objectPooler = GetComponent<ObjectPooler>();
        _target = FindObjectOfType<Target>().transform;
        _time = _enemy.FireRate;
    }

    void Update()
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
        if (collision.gameObject.GetComponent<Projectile>())
        {
            _enemyAnimationHandler.PlayHitAnimation();
            collision.gameObject.SetActive(false);

            float damage = collision.gameObject.GetComponent<Projectile>().SetDamage();
            float newHealth = _currentHealth -= damage;

            if (newHealth <= 0)
            {
                gameObject.SetActive(false);
                _currentHealth = _enemy.Health;
            }
        }
    }

    private void MoveAway()
    {
        transform.Translate(_enemy.Speed * 2 * Time.deltaTime * Vector2.left);
    }
}
