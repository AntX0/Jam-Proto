using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _forceAmmountToAdd;
    private LineRenderer _lineRenderer;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void OnMouseUp()
    {
        Vector3 currentPositon = GetComponent<Rigidbody2D>().position;
        Vector3 direction = currentPositon - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GetComponent<Rigidbody2D>().isKinematic = false;
        GetComponent<Rigidbody2D>().AddForce(direction.normalized * _forceAmmountToAdd, ForceMode2D.Force);
    }
}
