using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector2.left);
    }
}
