using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingBox : InteractibleItem
{
    [SerializeField] private UICrafting _uiCrafting;

    protected override void OnPlayerInteracted()
    {
        base.OnPlayerInteracted();
        _uiCrafting.gameObject.SetActive(true);
    }

    protected override void OnTriggerExit2D(Collider2D col)
    {
        base.OnTriggerExit2D(col);
        if (col.TryGetComponent(out Player player))
        {
            _uiCrafting.gameObject.SetActive(false);
        }
    }



}
