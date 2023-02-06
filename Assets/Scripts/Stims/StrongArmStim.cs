using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongArmStim : MonoBehaviour
{
    private MeleeAttackScript _playermeleedamage;
    private bool HasStongArmStim = false;
    private void Start()
    {
        _playermeleedamage = FindObjectOfType<MeleeAttackScript>();
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E) && HasStongArmStim == false)
        {
            _playermeleedamage._meleeDamage += 7;
            HasStongArmStim = true;
        }
    }
}
