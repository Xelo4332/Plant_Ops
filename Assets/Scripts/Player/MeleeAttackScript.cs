using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackScript : MonoBehaviour
{

    //Kacper
    [SerializeField] private  GameObject _meleeAttackHit;
    [SerializeField] public int _meleeDamage;
    private Player _player;

    //We'll find Player component
    private void Awake()
    {
        _player = GetComponent<Player>();
    }
    //This update will activate Meeleattack Method
    private void Update()
    {
        MeleeAttack();

    }

    //This function makes so that the hit box for the melle activates on the "V" button and gets the damage the melee does
    private void MeleeAttack()
    {
        if (_meleeAttackHit.activeSelf)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            var weaponDamage = _player.CurrentWeapon.Damage;
            _player.CurrentWeapon.UpdateDamage(_meleeDamage); // turns the "CurrentWeapon" damage to the melee damage
            _meleeAttackHit.SetActive(true); // activate the hitbox/point
            StartCoroutine(MeleeCooldown()); // start cooldown
            StartCoroutine(DisableWeaponCollider(weaponDamage)); //turns off hitbox/point


        }
    }

    // the name speaks for itself
    private IEnumerator MeleeCooldown()
    {
        yield return new WaitForSeconds(5);
    }


    private IEnumerator DisableWeaponCollider(int weaponDamage)
    {
        yield return new WaitForSeconds(0.5f); // whait for half a second
        _meleeAttackHit.SetActive(false); // Deactivate the hitbox/point
        _player.CurrentWeapon.UpdateDamage(weaponDamage); // turnes the weapon damage to its origin

    }



}

