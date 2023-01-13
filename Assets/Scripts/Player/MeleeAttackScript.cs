using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackScript : MonoBehaviour
{
    public event System.Action<int> EnemyAttack;

    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRange = 1f;
    [SerializeField] private int _meleeDamage = 3;

    public void Melee()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLayer); //  Makes a empty circle and dameges all things with the layer "_enemyLayer" that are in it-Kacper

        foreach (Collider2D enemy in hitEnemies)
        {
            EnemyAttack?.Invoke(_meleeDamage);
            enemy.GetComponent<Enemy>().MeleeDamage(_meleeDamage);


        }





    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



    }

    private void OnDrawGizmosSelected()
    {
        if (_attackPoint == null)
            return;
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }
}

