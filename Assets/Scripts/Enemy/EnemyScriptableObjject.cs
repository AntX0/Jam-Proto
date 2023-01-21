using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObjject", menuName = "ScriptableObjects/EnemyScriptableObject", order = 1)]
public class EnemyScriptableObjject : ScriptableObject
{
    [SerializeField] private float _health;
    [SerializeField] private float _speed;
    [SerializeField] private float _stoppingDistance;
    [SerializeField] private float _secondsBetweenShots;

    public float Health => _health;
    public float Speed => _speed;
    public float StoppingDistance => _stoppingDistance;
    public float SecondsBetweenShots => _secondsBetweenShots;
}
