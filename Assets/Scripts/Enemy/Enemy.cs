using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;
public class Enemy : MonoBehaviour
{
    public GameObject _blood;
    public event Action Ondie;
    [SerializeField] private int _health;
    [SerializeField] private BloodSplatter[] _bloodSplat;
    [SerializeField] private int _damage;
    private Game _game;
    private Animator _animator;
    private Coroutine _attackRoutine;
    protected Player _player;
    private CrossBow _crossbow;

    public int _currentHealth { get; private set; }
    private AIDestinationSetter _aiSetter;


    protected virtual void Awake()
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
        _health = Mathf.Min(100 + (_game.Round - 1) * 10, 300);

        _aiSetter.target = _player.transform;
    }


    protected virtual void OnTriggerEnter2D(Collider2D col)
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


    protected void TryGetDamage()
    {
        _health -= _player.CurrentWeapon.Damage;
        print(name);
        if (_health <= 0)
        {
            print("igen" + name);
            //_player._score++;
            _player.UpdateScore(1);
            Instantiate(_blood, transform.position, Quaternion.identity);
            Ondie?.Invoke();
            CreateBloodSplatter();
            Destroy(gameObject);
        }
        //_animator.SetTrigger("Hit");
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
        while (gameObject)
        {
            _player.TryGetDamage(_damage);
            yield return new WaitForSeconds(1);
        }
    }

    private void CreateBloodSplatter()
    {
        var index = UnityEngine.Random.Range(0, _bloodSplat.Length);
        Instantiate(_bloodSplat[index], transform.position, Quaternion.identity);

    }
}
