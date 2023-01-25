using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftMaterial : InteractibleItem
{
    protected override void OnPlayerInteracted()
    {
        Debug.Log("Player Intract with" + this.name);
    }
}
