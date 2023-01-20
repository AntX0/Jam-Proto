using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "ScriptableObjects/ProjectileScriptableObject", order = 1)]
public class ProjectileScriptableObject :ScriptableObject
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _damage = 10f;
    [SerializeField] private float _mass;

    public float Damage => _damage;
    public float Speed => _speed;
    public float Mass => _mass;
}
