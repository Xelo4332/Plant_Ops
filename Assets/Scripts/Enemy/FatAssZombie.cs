using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FatAssZombie : Enemy
    //Deni
{
    [SerializeField] private ParticleSystem _explosionEffects;
    [SerializeField] private int _explosionDamage;
    [SerializeField] private float _delayExplosion;
    [SerializeField] private float _explosionDistance;
    private Rigidbody2D _enemyBody;
    private AIDestinationSetter _destinationSetter;

    //Here we will override our awake method to get our Rigidbody component.
    protected override void Awake()
    {
        base.Awake();
        _enemyBody = GetComponent<Rigidbody2D>();
        _destinationSetter = GetComponent<AIDestinationSetter>();

    }
    //If enemy collider with player, it will turn off dessetter script, make rigidbody to static, freeze rotation and start expolosion courtine.
    protected override void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            _destinationSetter.enabled = false;
            _enemyBody.bodyType = RigidbodyType2D.Static;
            _enemyBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            StartCoroutine(ZombieExplosion());

        }
    }
    //Here will we have our Explosion delay and a simple checker to play couldn't activate it twice.
    private IEnumerator ZombieExplosion()
    {
        yield return new WaitForSeconds(_delayExplosion);
        if (gameObject)
        {
            Expolode();
        }
  

    }

   
    //Här kommer vi räkna ut distancen med hjälp av Vector 2 distance method som tillåter använda distancer istället för att skapa collider. 
    //Vi sätter en distans, om distans är större distans vi har skriven in, då kommer activeras method tryget damage.
    //Vi kommer också spawna particlar från våra prefabs och förstöra själva våran zombie objekten.
    private void Expolode()
    {
        if (Vector2.Distance(transform.position, _player.transform.position) < _explosionDistance)
        {
            _player.TryGetDamage(_explosionDamage);

        }
        Instantiate(_explosionEffects, transform.position, Quaternion.identity);
        Destroy(gameObject);
        

    }
}
