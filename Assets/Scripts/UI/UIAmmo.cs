using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAmmo : MonoBehaviour
{
    [SerializeField] private Text _ammoText;
    private Player _player;
    private Weapon _weapon;

    //Here we will find our components, activate few method and subcribe to a event.
    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _weapon = FindObjectOfType<Weapon>();
        OnAmmoUpdated();
        OnPLayerWeaponUpdated();
        _player.OnUpdateWeapon += OnPLayerWeaponUpdated;

    }
    //Our text will display current ammo int.
    private void OnAmmoUpdated()
    {
        _ammoText.text = _player.CurrentWeapon.Ammo.ToString();
    }
    //Here we will subcribe all of those event.
    private void OnDestroy()
    {
        _player.CurrentWeapon.UpdateAmmo -= OnAmmoUpdated;
        _player.OnUpdateWeapon -= OnPLayerWeaponUpdated;
    }
    //Here we will subcribe our ammo update event. Here we will update our ammo with help of signals.
    private void OnPLayerWeaponUpdated()
    {
        _player.CurrentWeapon.UpdateAmmo += OnAmmoUpdated;
    }

}
