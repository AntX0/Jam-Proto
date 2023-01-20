using UnityEngine;

public class BirdAnimationHandler : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayLeapAnimation()
    {
        _animator.SetTrigger("leap");
    }

}
