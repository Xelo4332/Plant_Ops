using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uzi : Weapon
{
    private void Update()
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
}
