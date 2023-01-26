using System;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public static event EventHandler OnCollison;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnCollison?.Invoke(this, null);
        collision.gameObject.SetActive(false);
    }
}
