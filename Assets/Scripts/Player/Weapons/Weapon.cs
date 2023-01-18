using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private Transform barrelTip;


    [SerializeField]
    private GameObject bullet;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private int _damage;
    public int Damage => _damage;

    protected float Timer;
    public float Firerate = 0.1f;

    [SerializeField] protected float AmmoCounter = 30f;
    [SerializeField] protected float MagSize;
    [SerializeField] protected float ChamberedMagSize;
    [SerializeField] protected float ReloadTime;
    protected bool IsReloading;




    public void CrossBowAction()
    {

    }
    // Spawning Bullets with help and bullet has RB
    public void Fire()
    {
        GameObject bulletInstance = Instantiate(bullet, barrelTip.position, barrelTip.rotation);
        bulletInstance.GetComponent<Rigidbody2D>().velocity = barrelTip.up * _bulletSpeed;

    }

    public void Reloading()
    {
        if (Input.GetKeyDown(KeyCode.R) && AmmoCounter > 0)
        {
            AmmoCounter = MagSize;
            IsReloading = true;
            Invoke("StopReloading", ReloadTime);
        }
        else if (Input.GetKeyDown(KeyCode.R) && AmmoCounter == 0)
        {
            AmmoCounter = ChamberedMagSize;
            IsReloading = true;
            Invoke("StopReloading", ReloadTime);
        }
    }
    private void StopReloading()
    {
        IsReloading = false;
    }

    private void Update()
    {
        Timer += Time.deltaTime;
        if (IsReloading == false)
        {
            if (Input.GetMouseButton(0) && Timer > Firerate && AmmoCounter > 0)
            {
                Fire();
                Timer = 0;
                AmmoCounter -= 1;
            }
        }

        Reloading();
    }

    public void UpdateDamage(int newDamage)
    {
        _damage = newDamage;
    }

}
