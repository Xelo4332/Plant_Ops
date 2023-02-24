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
    //PS. Jag vet att man kan göra variabelX, variabelY etc i en serializefield
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
        //If sats för att chhecka om du trycker R -Roni
        if (Input.GetKeyDown(KeyCode.R))
        {
            //Den här if else satsen kollar först om din ammunikation är över 0 och det är för en mer
            //Immersive reload type beat.
            //För att förklara koden lite mer så kollar den först om ditt ammo är mer än noll och om den
            //Är det så för du ett fullt magazine. Else är för om ditt ammo är lika med noll för att ge dig 
            //En mindre bullet. Så till exempel om du har en m4 med 14 skott is och reloadar så kommer du 31 skott.
            //Men om du har noll skott kvar så får du 30 -Roni
            if (AmmoCounter > 0)
            {
                //variabler för att fylla maget -Roni
                AmmoCounter = MagSize;
            }
            else
            {
                //Variabler för att fylla maget när du laddar ett skott in i the chamber -Roni
                AmmoCounter = ChamberedMagSize;
            }
            //Bool lean kod som sätts till true så att du inte kan skjuta medans du reloadar -Roni
            IsReloading = true;
            //Den här invoke koden kallar för funktionen StopReloading för att sätta isReloading till false
            //efter reload time som är en variabel -Roni
            Invoke("StopReloading", ReloadTime);
            UpdateAmmo?.Invoke();
            _weaponSource.clip = _reloadingSound;
            _weaponSource.Play();

        }

    }

    //Funktionen som är relaterad till reload koden -Roni
    private void StopReloading()
    {
        //Sätter IsReloading till false WOW -Roni
        IsReloading = false;
    }

    protected virtual void Update()
    {
        {
            //Timer som änvänds till firerate och en if sats som kollar om IsReloading ör lika med false -Roni
            Timer += Time.deltaTime;
            if (IsReloading == false)
            {
                //If sats för att kolla om du trycker på left click och om timer variabeln är större än
                //Firerate och ifall ditt ammo är mer än noll. lt det här är så att du kan skjuta -Roni
                if (Input.GetMouseButton(0) && Timer > Firerate && AmmoCounter > 0)
                {
                    //För varje skott så sänker den ammo med 1, callar för fire funktionen
                    //Och sätter timer på noll -Roni
                    AmmoCounter--;
                    Fire();
                    Timer = 0;
                }
            }
            //Sätter funktionen i update så att den kan bli tillkallad -Roni
            Reloading();
        }
    }

    public void UpdateDamage(int newDamage)
    {
        _damage = newDamage;
    }

}
