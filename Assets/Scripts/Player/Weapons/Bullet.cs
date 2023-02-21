using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _bullets;
    [SerializeField] private float Time;

    private void Update()
    {
        Destroy(gameObject, Time);
    }

    private void OnColliderEnter2D(Collider2D col)
    {
        if(col.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

}
