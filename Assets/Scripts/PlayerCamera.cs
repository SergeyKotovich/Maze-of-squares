using System;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
  [SerializeField] private Camera _playerCamera;
  [SerializeField] private Vector3 _offset;
  private PlayerController _player;

  public void SetPlayerPosition(PlayerController player)
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
