using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatAssZombie : Enemy
{
    private ParticleSystem _expolosionEffects;
    private Rigidbody2D _enemyBody;
    [SerializeField] private GameObject _explosioncollider;
    [SerializeField] private int _explosionDamage;
    [SerializeField] private float _exploidingTime;


    //We will override this method, get out base awake method from the enemy script and we will find our rigidbody2D.
    protected override void Awake()
    {
        base.Awake();
        _enemyBody = GetComponent<Rigidbody2D>();

    }

    //Here we override the method and we will get our base method from enemy script.
    //If player collides an object that hold player tag. Player will take Explosion damage, it will freeze the object both rotation and position.
    //It will start an coroutine.
    protected override void OnTriggerEnter2D(Collider2D col)
    {
        base.OnTriggerEnter2D(col);
        if (col.CompareTag("Player"))
        {
            _player.TryGetDamage(_explosionDamage);
            _enemyBody.constraints = RigidbodyConstraints2D.FreezePosition;
            _enemyBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            StartCoroutine(ZombieExplosion());

        }
    }

    //This is our timer when will zombie explode courtine.
    private IEnumerator ZombieExplosion()
    {
        yield return new WaitForSeconds(_exploidingTime);
        ExpolosionCollider();
    }

  
    //Bassicly here 
    private void ExpolosionCollider()
    {
        _explosioncollider.SetActive(true);
        Destroy(gameObject, 0.1f);

    }
}
