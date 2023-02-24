using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStim : MonoBehaviour
{
    // Script variabel f�r player och en bool lean statement -Roni
    private Player _playerHealth;
    private bool HasHealthStim = false;
    private void Start()
    {
        //Letar efter scriptet player -Roni
        _playerHealth = FindObjectOfType<Player>();
    }

    //F�r n�r spelaren �r inuti k�p arean -Roni
    public void OnTriggerStay2D(Collider2D collision)
    {
        //Kollar om din input �r lika med E och om du har health stimen aka om den �r false eller true -Roni
        if(Input.GetKey(KeyCode.E) && HasHealthStim == false)
        {
            //H�jer health v�rden i player scritet f�r att uppgradera den och s�tter det s� att man inte kan kk�pa den igen
            // I.E den s�tter boolen till true -Roni
            _playerHealth._health += 100;
            _playerHealth.RegenerationAmount += 10;
            HasHealthStim = true;
        }
    }
}
