using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class DoorBuying : InteractibleItem
{
    [SerializeField] private Player _player;
    [SerializeField] private int _price;

    //We will find our Player script
    private void Awake()
    {
        _player = FindObjectOfType<Player>();

    }
    //Works same as Weapon buying script, but this time we dectivate a object.
    protected override void OnPlayerInteracted()
    {
        if (_player._score >= _price)
        {
            _player.UpdateScore(-_price);
            this.gameObject.SetActive(false);
            Debug.Log("PlayerBuy");
        }
    }






}
