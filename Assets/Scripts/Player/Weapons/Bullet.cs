using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _bullets;
    [SerializeField] private float Time;

    private void Update()
    {
        Destroy(_bullets, Time);
    }

}
