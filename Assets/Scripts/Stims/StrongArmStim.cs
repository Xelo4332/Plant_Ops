using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongArmStim : MonoBehaviour
{
    //Like de andra s� finns det en bool lean variabel f�r ifall spelaren har powerupen och en access till player scriptet -Roni
    private MeleeAttackScript _playermeleedamage;
    private bool HasStongArmStim = false;
    private void Start()
    {
        //Den h�r linjen kod hittar MeleeAttackScript yadiyadiyada -Roni
        _playermeleedamage = FindObjectOfType<MeleeAttackScript>();
    }

    //En ontrigger grej (metod eller funktion idk) s� att bara kan k�pa inuti k�p arean -Roni
    public void OnTriggerStay2D(Collider2D collision)
    {
        //Kollar om du trycker E och om du redan har poweruppen -Roni
        if (Input.GetKey(KeyCode.E) && HasStongArmStim == false)
        {
            //H�jer melee damage i player scriptet till 10 (Fr�n 3) s�tter bool lean till true- -Roni
            _playermeleedamage._meleeDamage += 7;
            HasStongArmStim = true;
        }
    }
}
