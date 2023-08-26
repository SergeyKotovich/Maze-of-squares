using System;
using UnityEngine;

public class MousePositionController : MonoBehaviour
{
  [SerializeField] private PlayerController _playerController;
  [SerializeField] private LayerMask _layer;

  private void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      if (Physics.Raycast(ray, out var hitInfo, _layer))
      {
        var targetPosition =  hitInfo.point;
          _playerController.StartMove(targetPosition);
          Debug.Log(targetPosition);
      }
    }

    

  }
}