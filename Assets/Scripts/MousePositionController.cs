using System;
using UnityEngine;

public class MousePositionController : MonoBehaviour
{
  [SerializeField] private PlayerController _playerController;
  [SerializeField] private LayerMask _layer;

  private void Update()
  {
    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    if (Physics.Raycast(ray, out var hitInfo, _layer))
    {
      if (Input.GetMouseButtonDown(0))
      {
        Debug.Log("HER");
        var targetPosition = hitInfo.point;
        _playerController.StartMove(targetPosition);

      }
    }

    

  }
}