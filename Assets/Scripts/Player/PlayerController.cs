using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _forceAmmountToAdd = 10f;
    [SerializeField] private float _boundY;
    [SerializeField] private float _speed;

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
        if (Input.GetKey(KeyCode.Space) && transform.position.y < _boundY)
        {
            transform.position += Vector3.up * Time.deltaTime * _speed;
            _birdAnimationHandler.PlayLeapAnimation();
            /*AddForceTowardsSky();
            _objectPooler.SpawnObject();*/
        }
        else
        {
            transform.position += Vector3.down * Time.deltaTime * 5.5f;
        }
    }

}