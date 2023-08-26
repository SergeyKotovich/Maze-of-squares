using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerController _playerPrefab;
    [SerializeField] private float _speedMoving = 5f;
    [SerializeField] private Animator _animator;
    private PlayerController _player;
    private Vector3 _targetPosition;
    private float _stoppingDistance = 0.01f;
    private bool _isMoving ;
    private static readonly int Run = Animator.StringToHash("run");

    public PlayerController SpawnPlayer()
    {
       _player =  Instantiate(_playerPrefab);
       return _player;
    }
    private void Update()
    {
        PlayerMovement();
        
    }
    private void PlayerMovement()
    {
        
       if (!_isMoving)
       {
           return;
       }
       
       var distanceToDestination = Vector3.Distance(transform.position, _targetPosition);
       if (distanceToDestination <_stoppingDistance)
       {
           _isMoving = false;
           _animator.SetBool(Run, false);
            
       }
       var step = Time.deltaTime * _speedMoving;
       _player.transform.position = Vector3.MoveTowards(transform.position, _targetPosition, step);
       _player.transform.LookAt(_targetPosition);
       _animator.SetBool(Run, true);
       
        
        
    
        
    }

    public void StartMove(Vector3 targetPosition)
    {
        _isMoving = true;
        _targetPosition = targetPosition;
       
    }
}