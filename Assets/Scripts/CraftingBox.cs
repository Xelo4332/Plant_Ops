using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingBox : MonoBehaviour
{
    private Player _player;
    private InteractibleItems _items;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _items = FindObjectOfType<InteractibleItems>();
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.transform.name == "Player" && Input.GetKeyDown(KeyCode.E))
            if (_items._craftableItems >= 25)
            {

            }
    }



}
