
using UnityEngine;

public class MovementController 
{
    //Deni
    private readonly Rigidbody2D _playerBody;
    public Vector2 MoveDirection => _movementDirection;
    private Vector2 _movementDirection;
    private Animator _anim;



    public MovementController(Rigidbody2D playerBody, Animator playerAnimator)  
    {
        _playerBody = playerBody;
        _anim = playerAnimator;
    }

    //This is our move script. We will move with help of GetAxis method and make them to variable. Instead of writting the type of the variable will make a var so it will automacly detect it.
    //Then we will make that Movement direction variablal will become basscily direction where player will move.
    //And at last we will move our with help of velocity that our movement direction multiple with movement speed.
    public void Move(float movementSpeed)
    {
        var directionX = Input.GetAxis("Horizontal");
        var directionY = Input.GetAxis("Vertical");
        _movementDirection = new Vector2(directionX, directionY);
        _playerBody.velocity = _movementDirection * movementSpeed;

        //This is for our running animation. If Vector 2 isn't zero, then running animation will play.
        var isRunning = _movementDirection != Vector2.zero;
        _anim.SetBool("Running", isRunning);

    }

    //This is our method for player roation.
    public void Rotate(Vector3 angle)
    {
        _playerBody.transform.up = angle;
        
    }

}
