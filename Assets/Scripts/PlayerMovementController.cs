using System;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float _speedMoving = 2f;
    
    
    private Grid _grid;
    private Vector3 _targetPosition = new(6, 0, 3);
    private PlayerMovementController _player;
    private CharacterTeleportationController _characterTeleportationController;

    public Action CharacterHasFinishedMovement;
    public Action CharacterStartedMoving;
    
    
    
    
    public void Initialize( PlayerMovementController player , Grid grid , CharacterTeleportationController characterTeleportationController)
    {
        _grid = grid;
        _player = player;
        _characterTeleportationController = characterTeleportationController;
        
        _player.transform.position = _grid.WorldToCell(_targetPosition);
        var playerAnimationController = _player.GetComponentInChildren<PlayerMovementAnimationController>();
        playerAnimationController.Initialize(this , _characterTeleportationController);
        _characterTeleportationController.OnPlayerSwapPosition += GetTargetPoint;
    }
    
   private void Update()
   {
       MovePlayer();
       
   }

    private void MovePlayer()
    {
       
      
       if (_player.transform.position != _targetPosition )
       {
           _targetPosition = _grid.WorldToCell(_targetPosition);
           var step = _speedMoving * Time.deltaTime;
           _player.transform.position = Vector3.MoveTowards(_player.transform.position, _targetPosition, step);
           _player.transform.LookAt(_targetPosition);
       }
       else
       {
           CharacterHasFinishedMovement?.Invoke();
         //  
       }
    }

    public void GetTargetPoint(Vector3 targetPosition)
    {
        _targetPosition = targetPosition;
        CharacterStartedMoving?.Invoke();
        
    }

    private void OnDestroy()
    {
        _characterTeleportationController.OnPlayerSwapPosition -= GetTargetPoint;
    }
}
