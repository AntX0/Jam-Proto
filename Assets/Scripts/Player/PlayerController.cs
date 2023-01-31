using UnityEngine;

[RequireComponent(typeof(ObjectPooler))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(BirdAnimationHandler))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _forceAmountToAdd = 10f;
    [SerializeField] private float _boundY;
    [SerializeField] private float _speed;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _downPullSpeed;

    private ObjectPooler _objectPooler;
    private BirdAnimationHandler _birdAnimationHandler;
    private float _time;

    private void Awake()
    {
        _objectPooler = GetComponent<ObjectPooler>();
        _birdAnimationHandler = GetComponent<BirdAnimationHandler>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && transform.position.y < _boundY)
        {
            _birdAnimationHandler.PlayLeapAnimation();
            transform.position += Vector3.up * Time.deltaTime * _speed;
        }
        else
        {
            transform.position += Vector3.down * Time.deltaTime * _downPullSpeed;
        }

        ProcessShoot(); 
    }

    private void ProcessShoot()
    {
        _time += Time.deltaTime;
        float nextTimeToFire = 1 / _fireRate;

        if (_time >= nextTimeToFire && Input.GetKeyDown(KeyCode.Z))
        {
            _time = 0;
            _objectPooler.SpawnObject();
        }
    }
}