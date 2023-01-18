using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M1 : Weapon
{

    private void Update()
    {
        Timer += Time.deltaTime;
        if (IsReloading == false)
        {
            if (Input.GetMouseButtonDown(0) && Timer > Firerate && AmmoCounter > 0)
            {
                Fire();
                Timer = 0;
                AmmoCounter -= 1;
            }
        }

        Reloading();
    }
}
