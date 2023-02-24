using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongArmStim : MonoBehaviour
{
    //Like de andra så finns det en bool lean variabel för ifall spelaren har powerupen och en access till player scriptet -Roni
    private MeleeAttackScript _playermeleedamage;
    private bool HasStongArmStim = false;
    private void Start()
    {
        //Den här linjen kod hittar MeleeAttackScript yadiyadiyada -Roni
        _playermeleedamage = FindObjectOfType<MeleeAttackScript>();
    }

    //En ontrigger grej (metod eller funktion idk) så att bara kan köpa inuti köp arean -Roni
    public void OnTriggerStay2D(Collider2D collision)
    {
        //Kollar om du trycker E och om du redan har poweruppen -Roni
        if (Input.GetKey(KeyCode.E) && HasStongArmStim == false)
        {
            //Höjer melee damage i player scriptet till 10 (Från 3) sätter bool lean till true- -Roni
            _playermeleedamage._meleeDamage += 7;
            HasStongArmStim = true;
        }
    }
}
