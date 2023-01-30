using UnityEngine;

[CreateAssetMenu(fileName = "EnemyBrain", menuName = "ScriptableObjects/Brains/RusherBrain", order = 2)]
public class RusherBrain : EnemyBrain
{
    [SerializeField] private EnemyScriptableObjject _enemy;

    public override void Move(EnemyAI enemyAI)
    {
        enemyAI.transform.position = Vector2.MoveTowards(enemyAI.transform.position, enemyAI.Target.position, _enemy.Speed * Time.deltaTime);
    }
}
