using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Weapon : MonoBehaviour
{
    public event Action UpdateAmmo;

    [SerializeField]
    private Transform barrelTip;


    [SerializeField]
    private GameObject bullet;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private int _damage;
    public int Damage => _damage;
    public float Ammo => AmmoCounter;

    //Variabler relaterad till firerate -Roni
    protected float Timer;
    public float Firerate = 0.1f;

    //Variabler relaterad till ammo och reload kod -Roni
    //PS. Jag vet att man kan g�ra variabelX, variabelY etc i en serializefield
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


    
    // Spawning Bullets with help and bullet has RB
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
        //If sats f�r att chhecka om du trycker R -Roni
        if (Input.GetKeyDown(KeyCode.R))
        {
            //Den h�r if else satsen kollar f�rst om din ammunikation �r �ver 0 och det �r f�r en mer
            //Immersive reload type beat.
            //F�r att f�rklara koden lite mer s� kollar den f�rst om ditt ammo �r mer �n noll och om den
            //�r det s� f�r du ett fullt magazine. Else �r f�r om ditt ammo �r lika med noll f�r att ge dig 
            //En mindre bullet. S� till exempel om du har en m4 med 14 skott is och reloadar s� kommer du 31 skott.
            //Men om du har noll skott kvar s� f�r du 30 -Roni
            if (AmmoCounter > 0)
            {
                //variabler f�r att fylla maget -Roni
                AmmoCounter = MagSize;
            }
            else
            {
                //Variabler f�r att fylla maget n�r du laddar ett skott in i the chamber -Roni
                AmmoCounter = ChamberedMagSize;
            }
            //Bool lean kod som s�tts till true s� att du inte kan skjuta medans du reloadar -Roni
            IsReloading = true;
            //Den h�r invoke koden kallar f�r funktionen StopReloading f�r att s�tta isReloading till false
            //efter reload time som �r en variabel -Roni
            Invoke("StopReloading", ReloadTime);
            UpdateAmmo?.Invoke();
            _weaponSource.clip = _reloadingSound;
            _weaponSource.Play();

        }

    }

    //Funktionen som �r relaterad till reload koden -Roni
    private void StopReloading()
    {
        //S�tter IsReloading till false WOW -Roni
        IsReloading = false;
    }

    protected virtual void Update()
    {
        {
            //Timer som �nv�nds till firerate och en if sats som kollar om IsReloading �r lika med false -Roni
            Timer += Time.deltaTime;
            if (IsReloading == false)
            {
                //If sats f�r att kolla om du trycker p� left click och om timer variabeln �r st�rre �n
                //Firerate och ifall ditt ammo �r mer �n noll. lt det h�r �r s� att du kan skjuta -Roni
                if (Input.GetMouseButton(0) && Timer > Firerate && AmmoCounter > 0)
                {
                    //F�r varje skott s� s�nker den ammo med 1, callar f�r fire funktionen
                    //Och s�tter timer p� noll -Roni
                    AmmoCounter--;
                    Fire();
                    Timer = 0;
                }
            }
            //S�tter funktionen i update s� att den kan bli tillkallad -Roni
            Reloading();
        }
    }

    public void UpdateDamage(int newDamage)
    {
        _damage = newDamage;
    }

}
