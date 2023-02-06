using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackScript : MonoBehaviour
{

    //Kacper
    [SerializeField] private  GameObject _meleeAttackHit;
    [SerializeField] public int _meleeDamage = 3;
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

    //
    private void MeleeAttack()
    {
        if (_meleeAttackHit.activeSelf)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            var weaponDamage = _player.CurrentWeapon.Damage;
            _player.CurrentWeapon.UpdateDamage(_meleeDamage);
            _meleeAttackHit.SetActive(true);
            StartCoroutine(MeleeCooldown());
            StartCoroutine(DisableWeaponCollider(weaponDamage));


        }
    }

    private IEnumerator MeleeCooldown()
    {
        yield return new WaitForSeconds(5);
    }
    private IEnumerator DisableWeaponCollider(int weaponDamage)
    {
        yield return new WaitForSeconds(0.5f);
        _meleeAttackHit.SetActive(false);
        _player.CurrentWeapon.UpdateDamage(weaponDamage);
    }



}

