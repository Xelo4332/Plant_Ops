using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public event Action Interact;
    public event Action OnhealthUpdate;
    [Range(0, 100)]
    [SerializeField] private int _health;
    [SerializeField] public int MaxHealth = 100;
    [SerializeField] public int RegenerationAmount = 10;
    public int Health => _health;
    public event Action OnScoreUpdate;
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
        _crossBow = GetComponent<CrossBow>();
        _anim = GetComponent<Animator>();
        _movementController = new MovementController(_playerBody, _anim);
        _mainCamera = Camera.main;
        _normalSpeed = _movementSpeed;
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            Quit();
        }
        _movementController.Rotate(GetMouseWorldPosition());
        InteractHandle();
        /*
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
        */
    }

    //Med hj�lp av Vector 2, vi kan hitta v�ran mus position som �r ocks� en  input. V�ran karakt�r kommer fokursa p� mus hela tiden.
    //Vi ska inte gl�mma att anv�nda normalized s� att vectorer har samma poistionen;
    //Som ni kan see v�ran method �r Vector 2. D�rf�r beh�ver vi returna tillbaks direction v�rde.
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
        while (_health < MaxHealth)
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
        }
    }

    public void UpdateScore(int score)
    {
        _score += score;
        OnScoreUpdate?.Invoke();
    }
}
