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
    private Animator _animator;
    private Coroutine _attackRoutine;
    private Player _player;

    public int _currentHealth { get; private set; }

    private AIDestinationSetter _aiSetter;

    private void Awake()
    {
        _aiSetter = GetComponent<AIDestinationSetter>();
        _animator = GetComponent<Animator>();
        _player = FindObjectOfType<Player>();
        if (_player == null)
        {
            Debug.LogError($"Player not found in {name} class!");
            return;
        }
        _aiSetter.target = _player.transform;
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            TryGetDamage();
            Destroy(col.gameObject);
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
    public void MeleeDamage(int _trueDamage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - _trueDamage, 0, _health);
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

    private IEnumerator AttackRoutine()
    {
        while(gameObject)
        {
            _player.TryGetDamage(_damage);
            yield return new WaitForSeconds(1);
        }
    }

}
