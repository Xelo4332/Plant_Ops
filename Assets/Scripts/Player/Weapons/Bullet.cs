using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Sherzad
    [SerializeField] private GameObject _bullets;
    [SerializeField] private float Time;
    //Kommer förstöra skottet beror på när tider går ut.
    private void Update()
    {
        Destroy(gameObject, Time);
    }
    //Om skotten träffar något objekt, då kommer den automatisk förstöra den
    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(gameObject);
    }

}
