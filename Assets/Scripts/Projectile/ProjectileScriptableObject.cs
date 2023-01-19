using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "ScriptableObjects/ProjectileScriptableObject", order = 1)]
public class ProjectileScriptableObject :ScriptableObject
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _mass;
    [SerializeField] private GameObject _projectilePrefab;

    public float Speed => _speed;
    public float Mass => _mass;
    public GameObject ProjectilePrefab => _projectilePrefab;
}
