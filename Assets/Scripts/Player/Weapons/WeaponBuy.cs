using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBuy : MonoBehaviour
{
    [SerializeField] private GameObject _weapon;
    [SerializeField] private int _price;

    
    private Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D col)
    {
        if (_player._score >= _price)
      { 
         
        if (Input.GetKey(KeyCode.E) && _weapon.active == false && col.gameObject.transform.name == "Player")
        {
                _player._score -= _price;
            _weapon.SetActive(true);
        }
      }

       

    }
}
