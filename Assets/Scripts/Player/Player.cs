using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{   //Deni and Casper
    public event Action Interact;
    public event Action OnhealthUpdate;
    public event Action OnUpdateWeapon;
    public event Action OnScoreUpdate;
    [Range(0, 100)]
    [SerializeField] public int _health;
    [SerializeField] public int RegenerationAmount;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private AudioClip _walkSound;
    private MovementController _movementController;
    private float _sprintSpeed = 20;
    private float _normalSpeed = 10;
    private Rigidbody2D _playerBody;
    private Camera _mainCamera;
    public CrossBow _crossBow;
    private Animator _anim;
    private GameObject _meleeAttackHit;
    public Weapon CurrentWeapon => _weapon;
    private Coroutine _regernerationRoutine;
    public int _score;


    public void Quit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    //Here we will find all of our components that needed.
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
        if (Input.GetKeyDown(KeyCode.M))
        {
            Quit();
        }
        //Deni
        //Here we will activate our GetMouseWold postion method, intreacthandler and play our walking sound.
        //For the walking sound we had a issue that it played to fast to hear. I decided to make a trick.
        //It will first play first sound that it will loop. It means that we will hear the walking sound and it will not loop to fast.
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
        //Deni Here we will activate our move method for movement and sprint
        _movementController.Move(_movementSpeed);
        Sprint();
    }

    //Try get damage method that will make that player could take a damage. It wil reload the scene if player dies. Here we will activate regen method and invoke Onhealth event.
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
    //An simple sprint method.
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

    //Here we will start our courtine that will regen player helath.
    private void StartRegeneration()
    {
        if (_regernerationRoutine != null)
        {
            StopCoroutine(_regernerationRoutine);
            _regernerationRoutine = null;
        }
        _regernerationRoutine = StartCoroutine(RegernerationRoutine());
    }
    
    //A regen couretine, if three second coldown has ended, it was start while kiio and start adding health to player.
    // we will invoke our Onhealth event.
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
    //This is going to be our base for the item intreaction that we will refrense in other scripts.
    private void InteractHandle()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact?.Invoke();
        }
    }

    //Here's method that will be used to change weapon if you bu� a weapon or intract with the mustery box. 
    //It will destroy current gun object, get the new one from the prefabs, and invoke OnUpdate event.
    public void UpdateWeapon(Weapon newWeapon)
    {
        if (_weapon != newWeapon)
        {
            Destroy(_weapon.gameObject);
            _weapon = Instantiate(newWeapon, transform);
            OnUpdateWeapon?.Invoke();
        }
    }
    //This is to update player score and Invoke Onscore event.
    public void UpdateScore(int score)
    {
        _score += score;
        OnScoreUpdate?.Invoke();
    }

}
