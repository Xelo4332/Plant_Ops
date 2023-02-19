
using UnityEngine;

public class MovementController 
{
    private readonly Rigidbody2D _playerBody;
    public Vector2 MoveDirection => _movementDirection;
    private Vector2 _movementDirection;
    private Animator _anim;



    public MovementController(Rigidbody2D playerBody, Animator playerAnimator)  
    {
        _playerBody = playerBody;
        _anim = playerAnimator;
    }

    public void Move(float movementSpeed)
    {
        var directionX = Input.GetAxis("Horizontal");
        var directionY = Input.GetAxis("Vertical");
        _movementDirection = new Vector2(directionX, directionY);
        _playerBody.velocity = _movementDirection * movementSpeed;

        var isRunning = _movementDirection != Vector2.zero;
        _anim.SetBool("Running", isRunning);

    }

    public void Rotate(Vector3 angle)
    {
        _playerBody.transform.up = angle;
        
    }

}
