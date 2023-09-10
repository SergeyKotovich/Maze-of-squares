using System;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [field:SerializeField] public int Id { get; private set; }
    public Action<int, Vector3> OnPlayerTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var positionPlayer = other.transform.position;
            OnPlayerTrigger?.Invoke(Id,positionPlayer);
           
        }
    }
}