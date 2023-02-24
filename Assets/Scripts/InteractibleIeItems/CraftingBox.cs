using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Deni
public class CraftingBox : InteractibleItem
{
    [SerializeField] private UICrafting _uiCrafting;

    //Here we will set ui crafting gameobject true when we interact with crafting table.
    protected override void OnPlayerInteracted()
    {
        base.OnPlayerInteracted();
        _uiCrafting.gameObject.SetActive(true);
    }
    //If we will exit from collider area, then UI crafting screen will turn off.
    protected override void OnTriggerExit2D(Collider2D col)
    {
        base.OnTriggerExit2D(col);
        if (col.TryGetComponent(out Player player))
        {
            _uiCrafting.gameObject.SetActive(false);
        }
    }



}
