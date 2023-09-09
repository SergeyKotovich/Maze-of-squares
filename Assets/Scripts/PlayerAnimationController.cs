using System;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private static readonly int Run = Animator.StringToHash("run");
    private PlayerMovementController _player;

    public void Initialize(PlayerMovementController player)
    {
        _player = player;
        _player.CharacterStartedMoving += OnRunningAnimation;
        _player.CharacterHasFinishedMovement += OffRunningAnimation;
    }

    private void OnRunningAnimation()
    {
        _animator.SetBool(Run,true);
    }

    private void OffRunningAnimation()
    {
        _animator.SetBool(Run,false);
    }

    private void OnDestroy()
    {
        _player.CharacterStartedMoving -= OnRunningAnimation;
        _player.CharacterHasFinishedMovement -= OffRunningAnimation;
    }
}
