using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAmmo : MonoBehaviour
{
    [SerializeField] private Text _ammoText;
    private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        OnAmmoUpdated();
        OnPLayerWeaponUpdated();
        _player.OnUpdateWeapon += OnPLayerWeaponUpdated;

    }
    private void OnAmmoUpdated()
    {
        _ammoText.text = _player.CurrentWeapon.Ammo.ToString();
    }

    private void OnDestroy()
    {
        _player.CurrentWeapon.UpdateAmmo -= OnAmmoUpdated;
        _player.OnUpdateWeapon -= OnPLayerWeaponUpdated;
    }

    private void OnPLayerWeaponUpdated()
    {
        _player.CurrentWeapon.UpdateAmmo += OnAmmoUpdated;
    }
}
