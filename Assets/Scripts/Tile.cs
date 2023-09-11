using System;
using System.Collections;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [field:SerializeField] public int Id { get; private set; }
    public Action<int, Vector3, Transform> OnPlayerTrigger;
    private Vector3 _positionPlayer;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(WaitingTimeBeforeSwap());
            _positionPlayer = other.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StopAllCoroutines();
            
        }
    }

    private IEnumerator WaitingTimeBeforeSwap()
    {
        yield return new WaitForSeconds(3);
        OnPlayerTrigger?.Invoke(Id,_positionPlayer, transform );
    }
}