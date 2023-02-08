using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAmmo : MonoBehaviour
{
    [SerializeField] private Text _ammoText;
    private Player _player;
    private Weapon _weapon;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _weapon = FindObjectOfType<Weapon>();

        OnAmmoUpdated();
        OnPLayerWeaponUpdated();
        _player.OnUpdateWeapon += OnPLayerWeaponUpdated;

    }
    private void OnAmmoUpdated()
    {
        StartCoroutine(ReloadTimer());
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
    private IEnumerator ReloadTimer()
    {
        yield return new WaitForSeconds(_weapon.ReloadTime);
        _ammoText.text = _player.CurrentWeapon.Ammo.ToString();
    }
}
