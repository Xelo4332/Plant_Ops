using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBow : MonoBehaviour
{
    [SerializeField] private Transform barrelTip;

    [SerializeField] private GameObject bolt;



    [SerializeField] private float _boltSpeed;
    [SerializeField] public int _boltDamage = 3;

    private Player _player;
    private Enemy _enemy;
    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<Player>();
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        CrossBowAttack();
    }
    private void CrossBowAction()
    {
        GameObject boltInstance = Instantiate(bolt, barrelTip.position, barrelTip.rotation);
        boltInstance.GetComponent<Rigidbody2D>().velocity = barrelTip.up * _boltSpeed;
        Destroy(boltInstance, 5);
    }

    private void CrossBowAttack()
    {

        if (Input.GetKeyDown(KeyCode.L))
        {

            CrossBowAction();

        }



    }

    // Update is called once per frame

}
