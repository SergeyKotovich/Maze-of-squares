using System;
using UnityEngine;

public class PlayerSpawnController : MonoBehaviour
{
    [SerializeField] private PlayerMovementController _playerPrefab;
    
    public PlayerMovementController SpawnPlayer()
    {
       var player = Instantiate(_playerPrefab);
       return player;
    }
   
}