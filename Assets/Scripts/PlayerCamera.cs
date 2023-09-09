using System;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
  [SerializeField] private Camera _playerCamera;
  [SerializeField] private Vector3 _offset;
  private PlayerMovementController _player;

  public void SetPlayerPosition(PlayerMovementController player)
  {
      _player = player;
    
  }

  private void Update()
  {
      TrackingPlayer();
  }

  private void TrackingPlayer()
  {
    _playerCamera.transform.position = _player.transform.position + _offset;
  }
}
