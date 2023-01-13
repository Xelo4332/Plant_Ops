using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public event Action OnhealthUpdate;
    [Range(0, 100)]
    [SerializeField] private int _health;
    public int Health => _health;
    [SerializeField] private float _movementSpeed;
    private MovementController _movementController;
    private Rigidbody2D _playerBody;
    private Camera _mainCamera;
    private Weapon _weapon;
    public Weapon CurrentWeapon => _weapon;
    private Coroutine _regernerationRoutine;

    public int _score;



    private void Awake()
    {
        _playerBody = GetComponent<Rigidbody2D>();
        _weapon = GetComponent<Weapon>();
        _movementController = new MovementController(_playerBody);
        _mainCamera = Camera.main;

    }


    private void Update()
    {
        _movementController.Rotate(GetMouseWorldPosition());

    }


    private Vector2 GetMouseWorldPosition()
    {
        Vector2 mouseScreenPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouseScreenPosition - (Vector2)transform.position).normalized;
        return direction;

    }

    private void FixedUpdate()
    {
        _movementController.Move(_movementSpeed);
    }

    public void TryGetDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        StartRegeneration();
        OnhealthUpdate?.Invoke();
    }

    private void StartRegeneration()
    {
        if (_regernerationRoutine != null)
        {
             StopCoroutine(_regernerationRoutine);
            _regernerationRoutine = null;
        }
        _regernerationRoutine = StartCoroutine(RegernerationRoutine());
    }

    private IEnumerator RegernerationRoutine()
    {
        yield return new WaitForSeconds(3);
        while (_health < 100)
        {
            _health += 10;
            OnhealthUpdate?.Invoke();
            yield return new WaitForSeconds(1);
        }
    }



}
