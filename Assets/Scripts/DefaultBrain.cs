using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu(fileName = "EnemyBrain", menuName = "ScriptableObjects/DefaultBrain", order = 1)]
public class DefaultBrain : EnemyBrain
{
    [SerializeField] private EnemyScriptableObjject _enemy;

    public override void Move(EnemyAI AI)
    {
        AI.transform.Translate(_enemy.Speed * Time.deltaTime * Vector2.left);
    }
}
