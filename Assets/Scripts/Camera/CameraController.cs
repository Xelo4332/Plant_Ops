using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _followingTarget;
    private Vector3 _offset;

    private void Awake()
    {
        _offset = transform.position - _followingTarget.position;
    }

    private void LateUpdate()
    {
        transform.position = _followingTarget.position + _offset;
    }

}
