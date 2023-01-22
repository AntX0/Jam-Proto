using Unity.VisualScripting;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        collision.gameObject.SetActive(false);
    }
}
