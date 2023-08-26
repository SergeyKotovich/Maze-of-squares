using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private SpawnTilesController _spawnTilesController;
    [SerializeField] private DoorController _doorController;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private PlayerCamera _playerCamera;

    private void Awake()
    {
        _spawnTilesController.SpawnTiles();
        _doorController.SpawnDoor();
       var player = _playerController.SpawnPlayer();
       _playerCamera.SetPlayerPosition(player);
        
    }
}
