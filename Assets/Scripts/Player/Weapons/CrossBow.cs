using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBow : MonoBehaviour // -kacper
{
    [SerializeField] private Transform barrelTip;

    [SerializeField] private GameObject bolt;



    [SerializeField] private float _boltSpeed;
    [SerializeField] private int _boltDamage = 3;
    public int BoltDamage => _boltDamage;

    private Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<Player>();
    }

    private void CrossBowAction()
    {
        GameObject boltInstance = Instantiate(bolt, barrelTip.position, barrelTip.rotation); 
        boltInstance.GetComponent<Rigidbody2D>().velocity = barrelTip.up * _boltSpeed; // spawns bolt at the "barrelTip" position
        Destroy(boltInstance, 5);
    }

    public void CrossBowAttack()
    {

        if (Input.GetKeyDown(KeyCode.C)) // when "c" is pressed then the "CrossBowAction" method activates
        {

            CrossBowAction();

        }



    }

}
