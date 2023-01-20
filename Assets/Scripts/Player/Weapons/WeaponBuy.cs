using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBuy : MonoBehaviour
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
    private void OnTriggerStay2D(Collider2D col)
    {

        if ((col.TryGetComponent(out Player player)))
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (_player._score >= _price)
                {
                    _openAnimation.SetBool("Open", true);
                    _player._score -= _price;
                    _player.UpdateWeapon(_weapon);
                }
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _openAnimation.SetBool("Open", false);
    }
}
