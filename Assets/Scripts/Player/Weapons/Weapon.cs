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
        if (IsReloading == false)
        { 
           GameObject bulletInstance = Instantiate(bullet, barrelTip.position, barrelTip.rotation);
           bulletInstance.GetComponent<Rigidbody2D>().velocity = barrelTip.up * _bulletSpeed;
           AmmoCounter--;
        }
           

    }

    public void Reloading()
    {
        if (AmmoCounter > 0)
        {
            AmmoCounter = MagSize;
        }
        else if (AmmoCounter == 0)
        {
            AmmoCounter = ChamberedMagSize;
        }
        IsReloading = true;
        Invoke("StopReloading", ReloadTime);
    }
    private void StopReloading()
    {
        IsReloading = false;
    }



    public void UpdateDamage(int newDamage)
    {
        _damage = newDamage;
    }

}
