using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ShootingEnemy : MonoBehaviour, IEnemy
{
    [SerializeField] private float speed;
    [SerializeField] private int hp;
    [SerializeField] private int damage;
    [SerializeField] private float radiusOfVision;
    [SerializeField] private float startShootingRadius;
    [SerializeField] private float cooldown;
    [Space]
    [SerializeField] private Slider healthBar;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _shootPoint;

    private int playerLayerMask;
    private Transform _player;
    private Rigidbody2D _rb;
    private bool _isDeath;
    private int _currentHp;
    private NavMeshAgent _agent;
    private bool _onCooldown;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _currentHp = hp;
        _rb = GetComponent<Rigidbody2D>();
        healthBar.maxValue = hp;
        healthBar.value = hp;
        playerLayerMask = (int)Mathf.Log(playerLayer.value, 2);
    }

    void Update()
    {
        _rb.velocity = new Vector2();

        if (!_isDeath)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, _player.position);
            if (distanceToPlayer <= radiusOfVision && distanceToPlayer >= startShootingRadius)
            {
                Rotate();
                _agent.SetDestination(_player.transform.position);
            }
            else if (distanceToPlayer <= startShootingRadius)
            {
                Rotate();
                _agent.ResetPath();
                RaycastHit2D raycastHit = Physics2D.Raycast(_shootPoint.transform.position, _player.position, Mathf.Infinity);
                if (raycastHit.transform?.gameObject.layer == playerLayerMask)
                    if (!_onCooldown)
                        StartCoroutine(Attack());
            }
            if (_currentHp <= 0)
                _isDeath = true;
        }
        else
            StartCoroutine(Death());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == playerLayerMask && !_isDeath)
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }

    private IEnumerator Attack()
    {
        Instantiate(_bulletPrefab, _shootPoint.transform.position, _shootPoint.transform.rotation).GetComponent<EnemyBullet>().SetDamage(damage);
        _onCooldown = true;
        yield return new WaitForSeconds(cooldown);
        _onCooldown = false;
    }

    public void GetDamage(int damage)
    {
        _currentHp -= damage;
        healthBar.value = _currentHp;
    }

    public void Rotate()
    {
        Vector2 aimDirection = (Vector2)_player.position - _rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        _rb.rotation = aimAngle;
    }

    public IEnumerator Death()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
