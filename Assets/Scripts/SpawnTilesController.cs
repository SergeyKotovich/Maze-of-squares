using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTilesController : MonoBehaviour
{
    [SerializeField] private Grid _grid;
    [SerializeField] private List<Tile> _listPrefabs;

    [SerializeField] private Transform _parentRoot;

    private List<Tile> _listTiles = new();
// -1 - void
// 0 - white
// 1 - red
// 2 - green
// 3 - yellow
// 4 - blue
// 5 - purple

   

    public void SpawnTiles()
    {
        int[,] array =
        {
            { -1, -1, 0 },
            { 1, 2, 3 },
            { -1, -1, -1 },
            { 3, -1, 1 },
            { 4, -1, 5 },
            { -1, -1, -1 },
            { 4, 2, 5 }
        };
        for (var i = 0; i < array.GetLength(0); i++)
        {
            for (var j = 0; j < array.GetLength(1); j++)
            {
                switch (array[i, j])
                {
                    case -1:
                        continue;
                    case 0:
                    {
                        var whiteTile = Instantiate(_listPrefabs[0], _parentRoot);
                        whiteTile.transform.position = _grid.CellToWorld(new Vector3Int(i, 0, j));
                        _listTiles.Add(whiteTile);
                        break;
                    }
                    case 1:
                    {
                        var redTile = Instantiate(_listPrefabs[1], _parentRoot);
                        redTile.transform.position = _grid.CellToWorld(new Vector3Int(i, 0, j));
                        break;
                    }
                    case 2:
                    {
                        var greenTile = Instantiate(_listPrefabs[2], _parentRoot);
                        greenTile.transform.position = _grid.CellToWorld(new Vector3Int(i, 0, j));
                        break;
                    }
                    case 3:
                    {
                        var yellowTile = Instantiate(_listPrefabs[3], _parentRoot);
                        yellowTile.transform.position = _grid.CellToWorld(new Vector3Int(i, 0, j));
                        break;
                    }
                    case 4:
                    {
                        var blueTile = Instantiate(_listPrefabs[4], _parentRoot);
                        blueTile.transform.position = _grid.CellToWorld(new Vector3Int(i, 0, j));
                        break;
                    }
                    case 5:
                    {
                        var purpleTile = Instantiate(_listPrefabs[5], _parentRoot);
                        purpleTile.transform.position = _grid.CellToWorld(new Vector3Int(i, 0, j));
                        break;
                    }
                }
            }
        }
    }
}
