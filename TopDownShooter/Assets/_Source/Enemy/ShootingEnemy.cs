using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Zenject;

namespace EnemySystem
{
    public class ShootingEnemy : MonoBehaviour, IEnemy
    {
        private const int BULLET_AMOUNT = 15;

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
        [SerializeField] private Transform gun;

        private int playerLayerMask;
        private Rigidbody2D _rb;
        private bool _isDeath;
        private int _currentHp;
        private NavMeshAgent _agent;
        private bool _onCooldown;
        private EnemyBulletPool _bulletPool;

        [Inject]
        private Transform _player;

        void Start()
        {
            _currentHp = hp;
            _rb = GetComponent<Rigidbody2D>();
            healthBar.maxValue = hp;
            healthBar.value = hp;
            playerLayerMask = (int)Mathf.Log(playerLayer.value, 2);
            _bulletPool = new EnemyBulletPool(BULLET_AMOUNT,_bulletPrefab, _shootPoint.transform);
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
                    RaycastHit2D raycastHit2D = Physics2D.Raycast(_shootPoint.transform.position, _player.position - _shootPoint.transform.position, 100);

                    if (raycastHit2D.transform?.gameObject.layer == playerLayerMask)
                        if (!_onCooldown)
                            StartCoroutine(Attack());


                }
                if (_currentHp <= 0)
                    _isDeath = true;

                
            }
            else
                StartCoroutine(Death());
        }

        private IEnumerator Attack()
        {
            _bulletPool.GetFreeElement(damage);
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
            gun.rotation = Quaternion.AngleAxis(aimAngle, new Vector3(0, 0, 1));
        }

        public IEnumerator Death()
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(3f);
            gameObject.SetActive(false);
        }

        [Inject]
        public void Construct(GameObject player) => _player = player.transform;
    }
}