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



    protected override void Awake()
    {
        base.Awake();
        _enemyBody = GetComponent<Rigidbody2D>();

    }

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

    private IEnumerator ZombieExplosion()
    {
        yield return new WaitForSeconds(_exploidingTime);
        ExpolosionCollider();
    }

  

    private void ExpolosionCollider()
    {
        _explosioncollider.SetActive(true);
        Destroy(gameObject, 0.1f);

    }
}
