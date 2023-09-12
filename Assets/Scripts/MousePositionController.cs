using System;
using UnityEngine;

public class MousePositionController : MonoBehaviour
{
    [SerializeField] private LayerMask _layer;
    private PlayerMovementController _player;
    private void Update()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out var hitInfo, 50f, _layer))
        {
            return;
        }
        var targetPosition = hitInfo.point;
        Debug.Log(hitInfo.collider.gameObject.name);
        Debug.Log(hitInfo.point);
        _player.GetTargetPoint(targetPosition);
    }

    public void GetPlayerPosition(PlayerMovementController player)
    {
        _player = player;
        
    }
}
