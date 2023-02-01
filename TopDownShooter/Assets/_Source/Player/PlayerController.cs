using UnityEngine;

public class PlayerController
{
    private float _moveSpeed;
    private Rigidbody2D _rb;
    private Vector2 _moveDirection;

    public PlayerController(float moveSpeed, Rigidbody2D rb)
    {
        _moveSpeed = moveSpeed;
        _rb = rb;
    }

    public void Move(float moveX, float moveY)
    {
        _moveDirection = new Vector2(moveX, moveY).normalized;
        _rb.velocity = new Vector2(_moveDirection.x * _moveSpeed, _moveDirection.y * _moveSpeed);
    }
}