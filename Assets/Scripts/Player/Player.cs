using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public event Action Interact;
    public event Action OnhealthUpdate;
    public event Action OnUpdateWeapon;
    [Range(0, 100)]
    [SerializeField] public int _health;
    [SerializeField] public int RegenerationAmount;
    public event Action OnScoreUpdate;
    public event Action OnMaterialUpdate;
    [SerializeField] private float _movementSpeed;
    private MovementController _movementController;
    private float _sprintSpeed = 20;
    private float _normalSpeed = 10;
    private Rigidbody2D _playerBody;
    private Camera _mainCamera;
    [SerializeField] private Weapon _weapon;
    public CrossBow _crossBow;
    [SerializeField] private AudioClip _walkSound;
    private Animator _anim;
    private GameObject _meleeAttackHit;
    [SerializeField] private int _craftMaterial;
    public int Material => _craftMaterial;

    public Weapon CurrentWeapon => _weapon;
    private Coroutine _regernerationRoutine;

    public int _score;


    public void Quit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    private void Awake()
    {
        _playerBody = GetComponent<Rigidbody2D>();

        _anim = GetComponent<Animator>();
        _movementController = new MovementController(_playerBody, _anim);
        _mainCamera = Camera.main;
        _normalSpeed = _movementSpeed;



    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Quit();
        }
        _movementController.Rotate(GetMouseWorldPosition());
        InteractHandle();

        if (_movementController.MoveDirection != Vector2.zero)
        {
            if (AudioManager.instance.CurrentSoundEffct != _walkSound)
            {
                AudioManager.instance.PlaySoundEffect(_walkSound);
            }

        }
        else
        {
            if (AudioManager.instance.CurrentSoundEffct != null)
            {
                AudioManager.instance.ClearSoundEffect();
            }
        }

        if (_crossBow != null)
        {
            _crossBow.CrossBowAttack();
        }

    }

    //Med hjälp av Vector 2, vi kan hitta våran mus position som är också en  input. Våran karaktär kommer fokursa på mus hela tiden.
    //Vi ska inte glömma att använda normalized så att vectorer har samma poistionen;
    //Som ni kan see våran method är Vector 2. Därför behöver vi returna tillbaks direction värde.
    private Vector2 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;

        Vector2 mouseScreenPosition = _mainCamera.ScreenToWorldPoint(mousePos);
        Vector2 direction = (mouseScreenPosition - (Vector2)transform.position).normalized;
        return direction;
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {

        }
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
            _health += RegenerationAmount;
            OnhealthUpdate?.Invoke();
            yield return new WaitForSeconds(1);
        }
    }

    private void InteractHandle()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact?.Invoke();
        }
    }

    public void UpdateWeapon(Weapon newWeapon)
    {
        if (_weapon != newWeapon)
        {
            Destroy(_weapon.gameObject);
            _weapon = Instantiate(newWeapon, transform);
            OnUpdateWeapon?.Invoke();
        }
    }

    public void UpdateScore(int score)
    {
        _score += score;
        OnScoreUpdate?.Invoke();
    }

    public void UpdateMaterials(int count)
    {
        _craftMaterial += count;
        OnMaterialUpdate?.Invoke();
    }

    public void CrossBowActive()
    {
        Debug.Log("CrossBow");
        _crossBow = FindObjectOfType<CrossBow>();
    }

}
