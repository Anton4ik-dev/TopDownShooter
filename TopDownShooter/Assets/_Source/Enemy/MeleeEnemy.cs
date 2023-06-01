using CharacterSystem;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Zenject;

namespace EnemySystem
{
    public class MeleeEnemy : MonoBehaviour, IEnemy
    {
        [SerializeField] private float speed;
        [SerializeField] private int hp;
        [SerializeField] private int damage;
        [SerializeField] private float radiusOfVision;
        [SerializeField] private float attackCooldown;
        [Space]
        [SerializeField] private Slider healthBar;
        [SerializeField] private LayerMask playerLayer;
        [SerializeField] private EnemySound enemySound;
        [SerializeField] private EnemyAnimationSystem enemyAnimationSystem;
        [SerializeField] private GameObject sleepIcon;

        private int playerLayerMask;
        private Rigidbody2D _rb;
        private bool _isDeath;
        private int _currentHp;
        private NavMeshAgent _agent;
        private bool onCoolown;

        [Inject]
        private Transform _player;

        void Start()
        {
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
            enemySound.PlayIdleSound(true);
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
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.layer == playerLayerMask && !_isDeath)
            {
                if(!onCoolown)
                    StartCoroutine(Attack(collision.gameObject));
            }
        }

        private void Move()
        {
            float distanceToPlayer = Vector2.Distance(transform.position, _player.position);
            if (distanceToPlayer <= radiusOfVision)
            {
                SetLookDirection();
                _agent.SetDestination(_player.transform.position);
            } 
            if(_agent.hasPath)
                enemyAnimationSystem.Walk(true);
            else
                enemyAnimationSystem.Walk(false);
        }

        private void SetLookDirection()
        {
            if(transform.position.x - _player.position.x > 0)
            {
                transform.rotation = new Quaternion(0, 1, 0, 0);
            }
            else
            {
                transform.rotation = new Quaternion(0, 1, 0, 180);
            }
        }

        public void GetDamage(int damage)
        {
            _currentHp -= damage;
            healthBar.value = _currentHp;
            if (_currentHp <= 0)
            {
                _isDeath = true;
                enemyAnimationSystem.Death();
                StartCoroutine(Death());
            }
                
        }

        private IEnumerator Attack(GameObject target)
        {
            enemyAnimationSystem.Attack();
            target.GetComponent<CharacterView>().Health -= damage;
            onCoolown = true;
            yield return new WaitForSeconds(attackCooldown);
            onCoolown = false;
        }

        private IEnumerator Death()
        {
            GetComponent<SpriteRenderer>().color = Color.gray;
            sleepIcon.SetActive(true);
            enemySound.StopIdleSound();
            enemySound.PlayDeathSound(false);
            yield return new WaitForSeconds(3f);
            gameObject.SetActive(false);
        }

        [Inject]
        public void Construct(GameObject player) => _player = player.transform;
    }
}