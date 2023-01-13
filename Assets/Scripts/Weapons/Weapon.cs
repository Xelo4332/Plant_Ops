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

    private float Timer;
    public float Firerate = 0.1f;

    public float MagSize = 30f;
    [SerializeField] public float ReloadTime;
    private bool IsReloading;




    // Spawning Bullets with help and bullet has RB
    public void Fire()
    {
        GameObject bulletInstance = Instantiate(bullet, barrelTip.position, barrelTip.rotation);
        bulletInstance.GetComponent<Rigidbody2D>().velocity = barrelTip.up * _bulletSpeed;

    }

    private void Reloading()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            MagSize = 30;
            IsReloading = true;
            Invoke("StopReloading",ReloadTime);
        }
    }
    private void StopReloading()
    {
        IsReloading = false;
    }

    private void Update()
    {
        Timer += Time.deltaTime;
        if(IsReloading == false)
        {
            if (Input.GetMouseButton(0) && Timer > Firerate && MagSize > 0)
            {
                Fire();
                Timer = 0;
                MagSize -= 1;
            }
        }

        Reloading();
    }

}
