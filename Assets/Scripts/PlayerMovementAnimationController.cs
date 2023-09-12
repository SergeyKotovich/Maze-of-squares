using System;
using System.Collections;
using UnityEngine;

public class PlayerMovementAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private static readonly int Run = Animator.StringToHash("run");
    private PlayerMovementController _player;
    private static readonly int _movingDown = Animator.StringToHash("movingDown");
    private static readonly int _movingUp = Animator.StringToHash("movingUp");
    private CharacterTeleportationController _characterTeleportationController;

    public void Initialize(PlayerMovementController player, CharacterTeleportationController characterTeleportationController)
    {
        _player = player;
        _characterTeleportationController = characterTeleportationController;
        _player.CharacterStartedMoving += OnRunningAnimation;
        _player.CharacterHasFinishedMovement += OffRunningAnimation;
        _characterTeleportationController.CharacterStartedMovingDown += OnAnimationDownwardMovement;
    }

    private void OnRunningAnimation()
    {
        _animator.SetBool(Run,true);
    }

    private void OffRunningAnimation()
    {
        _animator.SetBool(Run,false);
    }

    private void OnAnimationDownwardMovement()
    {
        StartCoroutine(AnimationDownwardMovementCoroutine());
        
    }

    private IEnumerator AnimationDownwardMovementCoroutine()
    {
        yield return new WaitForSeconds(1);
        _animator.SetTrigger(_movingDown);
        yield return new WaitForSeconds(1);
        _animator.SetTrigger(_movingUp);
    }

    private void OnDestroy()
    {
        _player.CharacterStartedMoving -= OnRunningAnimation;
        _player.CharacterHasFinishedMovement -= OffRunningAnimation;
        _characterTeleportationController.CharacterStartedMovingDown -= OnAnimationDownwardMovement;
    }
}
