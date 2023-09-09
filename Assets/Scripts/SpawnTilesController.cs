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
                var value = array[i, j];

                if (value ==-1)
                {
                    continue;
                }
                var prefab = _listPrefabs[value];

                
                var tile = Instantiate(prefab,_parentRoot);
                tile.transform.position = _grid.WorldToCell(new Vector3Int(i, 0, j));
                _listTiles.Add(tile);
              
            }
        }
    }
}
