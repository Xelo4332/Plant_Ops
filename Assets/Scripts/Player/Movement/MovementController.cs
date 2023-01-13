
using UnityEngine;

public class MovementController 
{
    private readonly Rigidbody2D _playerBody;
    public Vector2 MoveDirection => _movementDirection;
    private Vector2 _movementDirection;

    public MovementController(Rigidbody2D playerBody)
    {
        _playerBody = playerBody;
    }

    public void Move(float movementSpeed)
    {
        var directionX = Input.GetAxis("Horizontal");
        var directionY = Input.GetAxis("Vertical");
        _movementDirection = new Vector2(directionX, directionY);
        _playerBody.velocity = _movementDirection * movementSpeed;
       
    }

    public void Rotate(Vector2 angle)
    {
        _playerBody.transform.up = angle;
        
    }

}
