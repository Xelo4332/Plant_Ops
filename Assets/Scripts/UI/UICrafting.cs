using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICrafting : MonoBehaviour
{
    private Player _player;
    private bool _isCrafted;

    //Here we will find our player script
    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }
    //If we don't have crossbow in our event and we will have enough material to buy it. Then it will activate crossbow, remove the score and make iscrafted bool true.
    public void CraftCrossBow()
    {
        if (!_isCrafted)
        {
            if (_player.Material >= 10)
            {
                _player.CrossBowActive();
                _player.UpdateMaterials(-10);
                _isCrafted = true;
            }
            
        }
        //Here we will turn off our ui.
        gameObject.SetActive(false);

    }
}
