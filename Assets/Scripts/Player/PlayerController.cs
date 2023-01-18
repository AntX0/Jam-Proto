using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private GameObject _projectilesPool;
    private Projectile _projectile;

    private void Update()
    {
        HandleObjectInstantiation();
    }

    private void HandleObjectInstantiation()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 2.0f;
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            Instantiate(_projectilePrefab, objectPos, Quaternion.identity, _projectilesPool.transform);
            _projectile = FindObjectOfType<Projectile>();
            _projectile.GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }
}
