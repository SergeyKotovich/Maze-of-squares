using System;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float _speedMoving = 2f;
    
    
    private Grid _grid;
    
    private Vector3 _targetPosition = new(6, 0, 1);
    private PlayerMovementController _player;
    private Vector3 _startPosition = new(6, 0, 1);
        
    public Action CharacterHasFinishedMovement;
    public Action CharacterStartedMoving;
    
    
    
    public void Initialize( PlayerMovementController player , Grid grid)
    {
        _grid = grid;
        _player = player;
        _player.transform.position = _grid.WorldToCell(_startPosition);
        var playerAnimationController = _player.GetComponentInChildren<PlayerAnimationController>();
        playerAnimationController.Initialize(this);
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
           _player.transform.LookAt(_targetPosition);
           var step = _speedMoving * Time.deltaTime;
           _player.transform.position = Vector3.MoveTowards(_player.transform.position, _targetPosition, step);
       }
       else
       {
           CharacterHasFinishedMovement?.Invoke();
       }
    }

    public void GetTargetPoint(Vector3 targetPosition)
    {
        _targetPosition = targetPosition;
        CharacterStartedMoving?.Invoke();
        
    }
}
