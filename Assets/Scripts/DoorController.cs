using DG.Tweening;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Vector3 _openDoorPosition;
    [SerializeField] private DoorController _doorPrefab;

    public void SpawnDoor()
    {
       Instantiate(_doorPrefab);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.DOLocalMove(_openDoorPosition, 1);
        }
        
    }

    
}
