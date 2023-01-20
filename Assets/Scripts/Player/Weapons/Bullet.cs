using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _bullets;

    private void Update()
    {
        Destroy(_bullets, 5);
    }

}
