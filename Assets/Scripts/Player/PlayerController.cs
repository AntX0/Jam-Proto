using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _forceAmmountToAdd = 10f;
    [SerializeField] private float _boundY;

    private ObjectPooler _objectPooler;
    private Rigidbody2D _rigidbody;
    private BirdAnimationHandler _birdAnimationHandler;

    private void Awake()
    {
        _objectPooler = GetComponent<ObjectPooler>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _birdAnimationHandler = GetComponent<BirdAnimationHandler>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _rigidbody.position.y < _boundY)
        {
            AddForceTowardsSky();
            _objectPooler.SpawnObject();
        }
    }

    private void AddForceTowardsSky()
    {
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.AddForce(Vector2.up * _forceAmmountToAdd);
        _birdAnimationHandler.PlayLeapAnimation();
    }
}