using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Sherzad
    [SerializeField] private GameObject _bullets;
    [SerializeField] private float Time;
    //Kommer f�rst�ra skottet beror p� n�r tider g�r ut.
    private void Update()
    {
        Destroy(gameObject, Time);
    }
    //Om skotten tr�ffar n�got objekt, d� kommer den automatisk f�rst�ra den
    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(gameObject);
    }

}
