using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class DoorBuying : MonoBehaviour
{
    [SerializeField] private Player _scoreDoor;
    [SerializeField] private int _scoreNeededToBuyDoor;
    [SerializeField] private int _scoreRemovalAfterBuy;

    private void Awake()
    {
        _scoreDoor = FindObjectOfType<Player>();

    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.TryGetComponent(out Player player))
        {
            if (_scoreDoor._score >= _scoreNeededToBuyDoor)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    this.gameObject.SetActive(false);
                    _scoreDoor._score -= _scoreNeededToBuyDoor;
                    Debug.Log(_scoreDoor);
                }
            }
        }
    }






}
