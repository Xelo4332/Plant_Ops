using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICrafting : MonoBehaviour
{
    private Player _player;
    private bool _isCrafted;

    private void Start()
    {
       _player = FindObjectOfType<Player>();
    }
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

        gameObject.SetActive(false);

    }
}
