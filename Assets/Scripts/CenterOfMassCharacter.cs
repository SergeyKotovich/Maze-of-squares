using System;
using UnityEngine;

public class CenterOfMassCharacter : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Vector3 _centerOfMass;

    private void Start()
    {
        _rigidbody.centerOfMass = _centerOfMass;
    }
}
