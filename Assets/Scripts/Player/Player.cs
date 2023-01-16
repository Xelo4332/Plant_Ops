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
    private float _sprintSpeed = 20;
    private float _normalSpeed = 10;
    private Rigidbody2D _playerBody;
    private Camera _mainCamera;
    private Weapon _weapon;
    private Animator _anim;
    private GameObject _meleeAttackHit;
    public Weapon CurrentWeapon => _weapon;
    private Coroutine _regernerationRoutine;

    public int _score;



    private void Awake()
    {
        _playerBody = GetComponent<Rigidbody2D>();
        _weapon = GetComponent<Weapon>();
        _anim = GetComponent<Animator>();
        _movementController = new MovementController(_playerBody, _anim);
        _mainCamera = Camera.main;
        _normalSpeed = _movementSpeed;
        



    }


    private void Update()
    {
        _movementController.Rotate(GetMouseWorldPosition());

    }

    //Med hjälp av Vector 2, vi kan hitta våran mus position som är också en  input. Våran karaktär kommer fokursa på mus hela tiden.
    //Vi ska inte glömma att använda normalized så att vectorer har samma poistionen;
    //Som ni kan see våran method är Vector 2. Därför behöver vi returna tillbaks direction värde.
    private Vector2 GetMouseWorldPosition()
    {
        Vector3 mouse = Input.mousePosition;
        mouse.z = -10;
        Vector2 mouseScreenPosition = _mainCamera.ScreenToWorldPoint(mouse);
        Vector2 direction = (mouseScreenPosition - (Vector2)transform.position).normalized;
        return direction;


    }

    private void FixedUpdate()
    {
        _movementController.Move(_movementSpeed);
        Sprint();
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

    private void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _movementSpeed = _sprintSpeed;
            _anim.SetBool("Sprinting", true);
        }
        else
        {
            _movementSpeed = _normalSpeed;
            _anim.SetBool("Sprinting", false);
        }
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
