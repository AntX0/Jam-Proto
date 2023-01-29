using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu(fileName = "EnemyBrain", menuName = "ScriptableObjects/Brains/DefaultBrain", order = 1)]
public class DefaultBrain : EnemyBrain
{
    [SerializeField] private EnemyScriptableObjject _enemy;

    public override void Move(EnemyAI enemyAI)
    {
        enemyAI.transform.position += _enemy.Speed * Time.deltaTime * Vector3.left;
    }
}
