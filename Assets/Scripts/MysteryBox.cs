using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryBox : InteractibleItem
{
    [SerializeField] private Weapon[] _weaponsDrop;
    private Player _player;
    [SerializeField] private int _price;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    private Weapon GetRandomWeapon()
    {
        var index = Random.Range(0, _weaponsDrop.Length);
        return _weaponsDrop[index];
    }

    protected override void OnPlayerInteracted()
    {
        if (_player._score >= _price)
        {
            _player.UpdateWeapon(GetRandomWeapon());
            _player.UpdateScore(-_price);
        }

    }

}
