using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigun : Weapon
{
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
}
