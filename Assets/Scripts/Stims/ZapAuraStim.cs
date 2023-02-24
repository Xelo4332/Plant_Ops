using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZapAuraStim : MonoBehaviour
{
    //Variiabler blah blah blah gamobject variabel blah blah blah -Roni
    private bool HasZapAura = false;
    [SerializeField]
    private GameObject Zap;
    public Weapon IsReloading;

    void Update()
    {
        //Kollar om du redan har stimen (Powerupen) och om du trycker E och om du reloadar -Roni
        if (HasZapAura == true && IsReloading && Input.GetKeyDown(KeyCode.E))
        {
            //Skapar gameobjectet Zap (Prefab grejen) vid spelarens position och förstör den efter en sekund -Roni
            //Inte helt klar -Roni
            Destroy(Instantiate(Zap, transform.position, Quaternion.identity), 1);
        }
    }
}
