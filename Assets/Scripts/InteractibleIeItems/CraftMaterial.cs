using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftMaterial : InteractibleItem
{
    private Player _player;
    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    protected override void OnPlayerInteracted()
    {
        _player.UpdateMaterials(1);
        Destroy(gameObject);
    }
}
