using UnityEngine;

public abstract class EnemyBrain : ScriptableObject
{
    public abstract void Move(EnemyAI enemyAI);
}
