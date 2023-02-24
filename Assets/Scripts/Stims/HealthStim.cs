using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStim : MonoBehaviour
{
    // Script variabel för player och en bool lean statement -Roni
    private Player _playerHealth;
    private bool HasHealthStim = false;
    private void Start()
    {
        //Letar efter scriptet player -Roni
        _playerHealth = FindObjectOfType<Player>();
    }

    //För när spelaren är inuti köp arean -Roni
    public void OnTriggerStay2D(Collider2D collision)
    {
        //Kollar om din input är lika med E och om du har health stimen aka om den är false eller true -Roni
        if(Input.GetKey(KeyCode.E) && HasHealthStim == false)
        {
            //Höjer health värden i player scritet för att uppgradera den och sätter det så att man inte kan kköpa den igen
            // I.E den sätter boolen till true -Roni
            _playerHealth._health += 100;
            _playerHealth.RegenerationAmount += 10;
            HasHealthStim = true;
        }
    }
}
