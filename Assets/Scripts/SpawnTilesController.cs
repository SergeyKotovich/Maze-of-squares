using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTilesController : MonoBehaviour
{
    [SerializeField] private Grid _grid;
    [SerializeField] private List<Tile> _listPrefabs;

    [SerializeField] private Transform _parentRoot;

    public List<Tile> ListTiles { get; } = new();
    
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
            { 6, 6, 0, 6},
            { 1, 2, 3, 6},
            { 6, 6, 6, 6},
            { 3, 6, 1, 6},
            { 4, 6, 5, 6},
            { 6, 6, 6, 6},
            { 4, 2, 5, 0}
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
                ListTiles.Add(tile);
              
            }
        }
    }
}
