using UnityEngine;

public class EnemyAnimationHandler : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAttackAnimation()
    {
        _animator.SetTrigger("attack");
    }

    public void PlayHitAnimation()
    {
        _animator.SetTrigger("Hit");
    }
}
