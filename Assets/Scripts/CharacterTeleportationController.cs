using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTeleportationController : MonoBehaviour
{
    private List<Tile> _listTiles;
    public void Initialize(List<Tile> listTiles)
    {
        _listTiles = listTiles;
        for (var i = 0; i < _listTiles.Count; i++)
        {
            _listTiles[i].OnPlayerTrigger += SwapPlayerPosition;
        }
    }

    private void SwapPlayerPosition(int id, Vector3 positionPlayer)
    {
        for (var i = 0; i < _listTiles.Count; i++)
        {
            if (id == _listTiles[i].Id)
            {
               var positionForSwap = _listTiles[i].transform.position;
               positionPlayer = positionForSwap;

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
