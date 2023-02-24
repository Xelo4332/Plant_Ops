using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftMaterial : InteractibleItem
{
    //Deni
    private Player _player;
    //We will find our player script to use update material method.
    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }
    //When we will interact with material, it will add us material, update ui and destroy it.
    protected override void OnPlayerInteracted()
    {
        _player.UpdateMaterials(1);
        Destroy(gameObject);
    }
}
