using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//OPS WE DO NOT USE THIS SCRIPT, WE USE INTREACTIBLE ITEM THAT IS LOCATED SAME FOLDER NAME
public class InteractibleItems : MonoBehaviour
{
    public int _craftableItems;
    private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.transform.name == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            _craftableItems++;
        }
    }

}
