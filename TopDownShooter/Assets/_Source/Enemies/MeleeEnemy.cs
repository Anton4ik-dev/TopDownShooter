using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MeleeEnemy : MonoBehaviour, IEnemy
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
    private NavMeshAgent _agent;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _currentHp = hp;
        _rb = GetComponent<Rigidbody2D>();
        healthBar.maxValue = hp;
        healthBar.value = hp;
        playerLayerMask = (int)Mathf.Log(playerLayer.value, 2);
    }

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
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
            StartCoroutine(Death());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == playerLayerMask && !_isDeath)
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }

    public void Move()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, _player.position);
        if (distanceToPlayer <= radiusOfVision)
            _agent.SetDestination(_player.transform.position);
    }

    

    public void GetDamage(int damage)
    {
        _currentHp -= damage;
        healthBar.value = _currentHp;
    }

    public IEnumerator Death()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}