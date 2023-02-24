using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Weapon : MonoBehaviour
{
    public event Action UpdateAmmo;
    [SerializeField]private Transform barrelTip;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private int _damage;
    public int Damage => _damage;
    public float Ammo => AmmoCounter;
    protected float Timer;
    public float Firerate = 0.1f;

    [SerializeField] protected float AmmoCounter = 30f;
    [SerializeField] protected float MagSize;
    [SerializeField] protected float ChamberedMagSize;
    [SerializeField] public float ReloadTime;
    protected bool IsReloading;
    [SerializeField] private AudioClip _reloadingSound;
    [SerializeField] private AudioClip _shoootingSound;
    [SerializeField] private MuzzleFlash _muzzleFlash;
    private AudioSource _weaponSource;

    private void Start()
    {
        _weaponSource = GetComponent<AudioSource>();
    }


    
    // Spawning Bullets with help and bullet has RB Deni and Roni
    //Here we will invoke our event, activate our muzzleflash gameobject and play shooting sound. //Deni
    public void Fire()
    {
        GameObject bulletInstance = Instantiate(bullet, barrelTip.position, barrelTip.rotation);
        bulletInstance.GetComponent<Rigidbody2D>().velocity = barrelTip.up * _bulletSpeed;
        UpdateAmmo?.Invoke();
        _muzzleFlash.gameObject.SetActive(true);
        _weaponSource.clip = _shoootingSound;
        _weaponSource.Play();

    }

    public void Reloading()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (AmmoCounter > 0)
            {
                AmmoCounter = MagSize;
            }
            else
            {
                AmmoCounter = ChamberedMagSize;
            }
            IsReloading = true;
            Invoke("StopReloading", ReloadTime);
            UpdateAmmo?.Invoke();
            _weaponSource.clip = _reloadingSound;
            _weaponSource.Play();

        }

    }
    private void StopReloading()
    {
        IsReloading = false;
    }

    protected virtual void Update()
    {
        {
            Timer += Time.deltaTime;
            if (IsReloading == false)
            {
                if (Input.GetMouseButton(0) && Timer > Firerate && AmmoCounter > 0)
                {
                    AmmoCounter--;
                    Fire();
                    Timer = 0;
                }
            }

            Reloading();
        }
        Reloading();
    }
    //Deni, this for our meelee damage script. Deni
    public void UpdateDamage(int newDamage)
    {
        _damage = newDamage;
    }

}
