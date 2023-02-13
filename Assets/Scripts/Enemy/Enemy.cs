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

    //Här får vi ut våra componenter som AIPathFinder, crossbow, etc.
    //Om vi väljer inte våra target, kommer den ge error för debug purpose
    //Vi gör att health ökas från game round script int variabel.
    //Vi hade problem med AI path finder, att när den var i prefab kunde den inte hitta player, därför gjorde vi läggde vi in det i awake så att när spelet startas, då enemy kommer ha target direkt.
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

    //Damage taking from bullets, meeleehit och crossbow med hjälp av ontrigger.
    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            EnemyTryGetDamage();
            Destroy(col.gameObject);
        }
        if (col.CompareTag("MeleeHit"))
        {
            EnemyTryGetDamage();
        }
        if (col.CompareTag("Bolt"))
        {
            TryGetDamageCrossbow();
        }

    }
    //Har starar vi Attackcoroutine och enemy börjar så ´player när dems collider colliderar.
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
    //Om player lämnar enemy collider, då kommer enemy avsluta sin attack coroutine.
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

    //Att enemy kommer börja ta damage från player current weapon.
    //Om nemey health är mindre än 0, då updtarear player score med hjälp av event, sen skapar vi blood particle effecs, Sen invokar vi on die event, 
    // Sen skapar vi prefab blood splater, efter det förstår vi enemy gameobject.
    private void EnemyTryGetDamage()
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

    //Detta är attack Coroutine som kommer användas i annan method. Vi har en referens här från player trygetdamage methoden. Vi använder corutine så att enemy har en damage coldwon.
    private IEnumerator AttackRoutine()
    {
        while (gameObject)
        {
            _player.TryGetDamage(_damage);
            yield return new WaitForSeconds(1);
        }
    }

    //Skapar en bloodsplater prefab object. Den kommer skapa random splatter gameobject med hjälp av random range.
    private void CreateBloodSplatter()
    {
        var index = UnityEngine.Random.Range(0, _bloodSplat.Length);
        Instantiate(_bloodSplat[index], transform.position, Quaternion.identity);

    }
}
