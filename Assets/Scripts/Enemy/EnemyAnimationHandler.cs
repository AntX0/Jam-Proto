using System.Collections;
using UnityEngine;

public class EnemyAnimationHandler : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void PlayAttackAnimation()
    {
        _animator.SetTrigger("attack");
    }

    public void PlayHitAnimation()
    {
        _animator.SetTrigger("Hit");
        StartCoroutine(SetHitColour());
    }

    private IEnumerator SetHitColour()
    {
        if (_animator.isActiveAndEnabled == false) { yield return null; }

        _spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        _spriteRenderer.color = Color.white;
    }
}
