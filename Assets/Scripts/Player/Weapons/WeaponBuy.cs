using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBuy : InteractibleItem
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private int _price;
    private Animator _openAnimation;


    private Player _player;
    //We will find Player script comment and Animator component.
    void Start()
    {
        _player = FindObjectOfType<Player>();
        _openAnimation = GetComponent<Animator>();

    }

    //We will overrride the method and use the base of method the script that we innheritance from.
    protected override void OnTriggerEnter2D(Collider2D col)
    {
        base.OnTriggerEnter2D(col);

    }

    //We ovveride here method too, so if play score is more than price, then we will play animation, update the score and update the weapon.
    protected override void OnPlayerInteracted()
    {
        if (_player._score >= _price)
        {
            _openAnimation.SetBool("Open", true);
            _player.UpdateScore(-_price);
            _player.UpdateWeapon(_weapon);
        }
    }

    //We will use base method and we will make open animation false, it means it will close.
    protected override void OnTriggerExit2D(Collider2D col)
    {
        base.OnTriggerExit2D(col);
        _openAnimation.SetBool("Open", false);
    }
}
