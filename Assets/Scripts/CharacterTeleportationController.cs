using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTeleportationController : MonoBehaviour
{
    private List<Tile> _listTiles;
    private PlayerMovementController _player;
    public Action <Vector3> OnPlayerSwapPosition;
    public void Initialize(List<Tile> listTiles, PlayerMovementController player)
    {
        _listTiles = listTiles;
        _player = player;
        for (var i = 0; i < _listTiles.Count; i++)
        {
            _listTiles[i].OnPlayerTrigger += SwapPlayerPosition;
        }
    }

    private void SwapPlayerPosition(int id, Vector3 positionPlayer, Transform tilePosition)
    {
        for (var i = 0; i < _listTiles.Count; i++)
        {
            if (id == _listTiles[i].Id && tilePosition != _listTiles[i].transform)
            {
               var positionForSwap = _listTiles[i].transform.position;
               _player.transform.position = positionForSwap;
               OnPlayerSwapPosition?.Invoke(positionForSwap);

            }
        }
    }

    private void OnDestroy()
    {
        for (var i = 0; i < _listTiles.Count; i++)
        {
            _listTiles[i].OnPlayerTrigger -= SwapPlayerPosition;
        }
    }
}
