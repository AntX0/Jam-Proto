using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDisabler : MonoBehaviour
{
    private GroundSpawner _groundSpawner;

    private void Awake()
    {
        _groundSpawner = FindObjectOfType<GroundSpawner>(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<GroundScroller>())
        {
            
            collision.gameObject.transform.position = _groundSpawner.transform.position;
        }
    }
}
