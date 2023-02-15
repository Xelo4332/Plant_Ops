using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryBox : InteractibleItem
{
    [SerializeField] private Weapon[] _weaponsDrop;
    private Player _player;
    [SerializeField] private int _price;

    //We will find our player script here
    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    //Here will we have a method that randmoize weapon that we will get, we will activate it on other method.
    private Weapon GetRandomWeapon()
    {
        var index = Random.Range(0, _weaponsDrop.Length);
        return _weaponsDrop[index];
    }

    //This method is like door buying script, but here is some changes, player will get a random weapon.
    protected override void OnPlayerInteracted()
    {
        if (_player._score >= _price)
        {
            _player.UpdateWeapon(GetRandomWeapon());
            _player.UpdateScore(-_price);
        }

    }

}
