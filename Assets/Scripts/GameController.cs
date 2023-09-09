using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private SpawnTilesController _spawnTilesController;
    [SerializeField] private DoorController _doorController;
    
    [SerializeField] private PlayerSpawnController _playerSpawnController;
    [SerializeField] private PlayerCamera _playerCamera;
    [SerializeField] private Grid _grid;
    [SerializeField] private MousePositionController _mousePositionController;
   


    private void Awake()
    {
        _spawnTilesController.SpawnTiles();
        _doorController.SpawnDoor();
        var player = _playerSpawnController.SpawnPlayer();
        player.Initialize(player,  _grid);
        _playerCamera.SetPlayerPosition(player);
        _mousePositionController.GetPlayerPosition(player);
       


    }
   
    
}
