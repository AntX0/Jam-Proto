using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    private Transform _ground;

    private void Start()
    {
        _ground = GetComponent<Transform>();    
    }

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }
}
