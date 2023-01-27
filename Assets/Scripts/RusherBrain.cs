using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu(fileName = "EnemyBrain", menuName = "ScriptableObjects/RusherBrain", order = 2)]
public class RusherBrain : EnemyBrain
{
    [SerializeField] private EnemyScriptableObjject _enemy;

    public override void Move(EnemyAI AI)
    {
        AI.transform.position = Vector2.MoveTowards(AI.transform.position, AI.Target.position, _enemy.Speed * Time.deltaTime);
    }
}
