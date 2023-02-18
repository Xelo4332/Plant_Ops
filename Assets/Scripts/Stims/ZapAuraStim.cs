using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZapAuraStim : MonoBehaviour
{
    private bool HasZapAura = false;
    [SerializeField]
    private GameObject Zap;
    public Weapon IsReloading;

    void Update()
    {
        if (HasZapAura == true && IsReloading && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(Instantiate(Zap, transform.position, Quaternion.identity), 1);
        }
    }
}
