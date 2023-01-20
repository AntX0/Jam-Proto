using Unity.VisualScripting;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Obstacle>() || collision.gameObject.GetComponent<EnemyAI>())
            Destroy(collision.gameObject);
    }
}
