using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObjject", menuName = "ScriptableObjects/EnemyScriptableObject", order = 1)]
public class EnemyScriptableObjject : ScriptableObject
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _speed;
    [SerializeField] private float _stoppingDistance;
    [SerializeField] private float _secondsBetweenShots;

    public float SecondsBetweenShots => _secondsBetweenShots;
    public float Speed => _speed;
    public float StoppingDistance => _stoppingDistance;
    public float Health;

    private void OnEnable()
    {
        Health = _maxHealth;
    }
    
    public float TakeDamage(float damage)
    {
        float newHealth = Health -= damage;
        if (newHealth < 0) 
        {
            Health = 0;  
        }
        return newHealth;
    }
}
