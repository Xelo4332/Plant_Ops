using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBuy : InteractibleItem
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private int _price;
    private Animator _openAnimation;


    private Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<Player>();
        _openAnimation = GetComponent<Animator>();

    }

    // Update is called once per frame
    protected override void OnTriggerEnter2D(Collider2D col)
    {
        base.OnTriggerEnter2D(col);

    }

    protected override void OnPlayerInteracted()
    {
        if (_player._score >= _price)
        {
            _openAnimation.SetBool("Open", true);
            _player.UpdateScore(-_price);
            _player.UpdateWeapon(_weapon);
        }
    }


    protected override void OnTriggerExit2D(Collider2D col)
    {
        base.OnTriggerExit2D(col);
        _openAnimation.SetBool("Open", false);
    }
}
