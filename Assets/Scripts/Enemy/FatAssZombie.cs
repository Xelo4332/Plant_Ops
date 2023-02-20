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


    //Here we will override our awake method to get our Rigidbody component.
    protected override void Awake()
    {
        base.Awake();
        _enemyBody = GetComponent<Rigidbody2D>();

    }
    //If play enter enemy explosion collider, enemy will freeze, deal damage and start explosion courtine.
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
    //Here we will set our timer when zombie will expload.
    private IEnumerator ZombieExplosion()
    {
        yield return new WaitForSeconds(_exploidingTime);
        ExpolosionCollider();
    }

  
    //Here we will turn on collider and destory player object after few miliseconds.
    private void ExpolosionCollider()
    {
        _explosioncollider.SetActive(true);
        Destroy(gameObject, 0.1f);

    }
}
