using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int hp;
    [SerializeField] private int damage;
    [SerializeField] private float radiusOfVision;
    [Space]
    [SerializeField] private Slider healthBar;
    [SerializeField] private LayerMask playerLayer;

    private int playerLayerMask;
    private Transform _player;
    private Rigidbody2D _rb;
    private bool _isDeath;
    private int _currentHp;

    void Start()
    {
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
            Move();
            if (_currentHp <= 0)
                _isDeath = true;
        }
        else
            GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == playerLayerMask && !_isDeath)
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
            Debug.Log($"Enemy damage player on {damage}");
        }
    }

    public void Move()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, _player.position);
        if (distanceToPlayer <= radiusOfVision)
            transform.position = Vector2.MoveTowards(transform.position, _player.position, speed * Time.deltaTime);
    }

    

    public void GetDamage(int damage)
    {
        _currentHp -= damage;
        healthBar.value = _currentHp;
    }
}