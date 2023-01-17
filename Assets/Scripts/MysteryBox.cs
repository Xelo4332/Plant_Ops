using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryBox : MonoBehaviour
{
    [SerializeField] private GameObject[] _weaponsDrop;
    private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    private GameObject GetRandomWeapon()
    {
        var index = Random.Range(0, _weaponsDrop.Length);
        return _weaponsDrop[index];
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.transform.name == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            GetRandomWeapon();
        }
    }
}
