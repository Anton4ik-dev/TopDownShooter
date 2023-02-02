using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Slider healthBar;
    [SerializeField] private float health;

    private Vector2 _moveDirection;
    private Vector2 _mousePosition;

    private void Awake()
    {
        healthBar.maxValue = health;
        healthBar.value = health;
    }

    public void Move(float moveX, float moveY)
    {
        _moveDirection = new Vector2(moveX, moveY).normalized;
        rb.velocity = new Vector2(_moveDirection.x * moveSpeed, _moveDirection.y * moveSpeed);
    }

    public void Rotate()
    {
        _mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimDirection = _mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }

    public void Shoot()
    {
        GameObject.Instantiate(bullet, shootPoint.position, shootPoint.rotation);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.value = health;

        if (health <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}