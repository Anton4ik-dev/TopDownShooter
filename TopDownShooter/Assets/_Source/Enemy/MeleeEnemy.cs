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
        [Space]
        [SerializeField] private Slider healthBar;
        [SerializeField] private LayerMask playerLayer;
        [SerializeField] private EnemySound enemySound;
        [SerializeField] private GameObject sleepIcon;

        private int playerLayerMask;
        private Rigidbody2D _rb;
        private bool _isDeath;
        private int _currentHp;
        private NavMeshAgent _agent;

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

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == playerLayerMask && !_isDeath)
            {
                collision.gameObject.GetComponent<CharacterView>().Health -= damage;
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
            if (_currentHp <= 0)
            {
                _isDeath = true;
                StartCoroutine(Death());
            }
                
        }

        public IEnumerator Death()
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