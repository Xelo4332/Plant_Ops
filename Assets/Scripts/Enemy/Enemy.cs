using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;
public class Enemy : MonoBehaviour
{
    public event Action Ondie;
    [SerializeField] private int _health;
    
    [SerializeField] private int _damage;
    private Game _game;
    private Animator _animator;
    private Coroutine _attackRoutine;
    private Player _player;
    private CrossBow _crossbow;
    

    public int _currentHealth { get; private set; }

    private AIDestinationSetter _aiSetter;

    private void Awake()
    {
        _crossbow = GetComponent<CrossBow>();
        _aiSetter = GetComponent<AIDestinationSetter>();
        _animator = GetComponent<Animator>();
        _player = FindObjectOfType<Player>();
        if (_player == null)
        {
            Debug.LogError($"Player not found in {name} class!");
            return;
        }
        _game = FindObjectOfType<Game>();
        _health = Mathf.Min(_game.Round + 2, 10);
        
        _aiSetter.target = _player.transform;
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            TryGetDamage();
            Destroy(col.gameObject);
        }
        if (col.CompareTag("MeleeHit"))
        {
            TryGetDamage();
        }
       if (col.CompareTag("Bolt"))
        {
            TryGetDamageCrossbow();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out Player player))
        {
            if (_attackRoutine == null)
            {
                _attackRoutine = StartCoroutine(AttackRoutine());
            }
        }

    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out Player player))
        {
            if (_attackRoutine != null)
            {
                StopCoroutine(_attackRoutine);
                _attackRoutine = null;
            }
        }
    }


    private void TryGetDamage()
    {
        _health -= _player.CurrentWeapon.Damage;

        if (_health <= 0)
        {
            _player._score++;
            Ondie?.Invoke();
            Destroy(gameObject);
        }
        _animator.SetTrigger("Hit");
    }

    private void TryGetDamageCrossbow()
    {
        _health -= _player._crossBow._boltDamage;

        if (_health <= 0)
        {
            _player._score++;
            Ondie?.Invoke();
            Destroy(gameObject);
        }
        _animator.SetTrigger("Hit");
    }

    private IEnumerator AttackRoutine()
    {
        while(gameObject)
        {
            _player.TryGetDamage(_damage);
            yield return new WaitForSeconds(1);
        }
    }

}
