using UnityEngine;

public class PlayerController
{
    private float _moveSpeed;
    private Rigidbody2D _rb;
    private Camera _camera;
    private GameObject _bullet;
    private Transform _shootPoint;

    private Vector2 _moveDirection;
    private Vector2 _mousePosition;

    public PlayerController(float moveSpeed, Rigidbody2D rb, Camera camera, GameObject bullet, Transform shootPoint)
    {
        _moveSpeed = moveSpeed;
        _rb = rb;
        _camera = camera;
        _bullet = bullet;
        _shootPoint = shootPoint;
    }

    public void Move(float moveX, float moveY)
    {
        _moveDirection = new Vector2(moveX, moveY).normalized;
        _rb.velocity = new Vector2(_moveDirection.x * _moveSpeed, _moveDirection.y * _moveSpeed);
    }

    public void Rotate()
    {
        _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimDirection = _mousePosition - _rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        _rb.rotation = aimAngle;
    }

    public void Shoot()
    {
        GameObject.Instantiate(_bullet, _shootPoint.position, _shootPoint.rotation);
    }
}