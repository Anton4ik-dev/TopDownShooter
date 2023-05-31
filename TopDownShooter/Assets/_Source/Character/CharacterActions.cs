using ScriptableObjects;
using System.Collections;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace CharacterSystem
{
    public class CharacterActions
    {
        private Rigidbody2D _rb;
        private Camera _mainCamera;
        private CharacterAnimator _characterAnimator;
        private BulletPool _pool;
        private float _shootDelay;
        private float _reloadTime;
        private int _maxHealth;
        private int _health;
        private int _damage;
        private float _moveSpeed;
        private LoseView _loseView;
        private Slider _ammo;

        public int MaxHealth
        {
            get => _maxHealth;
            set
            {
                _maxHealth = value;
            }
        }

        public int Health
        {
            get => _health;
            set
            {
                _health = value;
                if (_health < 0)
                {
                    _characterAnimator.SetDead();
                    _health = 0;
                    _loseView.DrawLosePanel();
                }
                else if (_health > _maxHealth)
                    _health = _maxHealth;
            }
        }

        public float MoveSpeed
        {
            get => _moveSpeed;
            set
            {
                _moveSpeed = value;
            }
        }

        public int Damage
        {
            get => _damage;
            set
            {
                _damage = value;
            }
        }

        public Slider Ammo { get => _ammo; private set { } }

        public CharacterActions(Rigidbody2D rb,
            Camera mainCamera, 
            CharacterAnimator characterAnimator,
            BulletPool bulletPool, 
            CharacterDataSO characterDataSO,
            LoseView loseView, Slider ammo)
        {
            _rb = rb;
            _mainCamera = mainCamera;
            _characterAnimator = characterAnimator;
            _pool = bulletPool;
            _shootDelay = characterDataSO.ShootDelay;
            _reloadTime = characterDataSO.ReloadTime;
            _maxHealth = characterDataSO.MaxHealth;
            _health = characterDataSO.MaxHealth;
            _damage = characterDataSO.Damage;
            _moveSpeed = characterDataSO.MoveSpeed;
            _loseView = loseView;
            _ammo = ammo;
        }

        public void Move(float moveX, float moveY)
        {
            Vector2 moveDirection = new Vector2(moveX, moveY).normalized;
            _rb.velocity = new Vector2(moveDirection.x * _moveSpeed, moveDirection.y * _moveSpeed);
            _characterAnimator.SetWalk(_rb.velocity.magnitude);
        }

        public void Rotate()
        {
            Vector2 mousePosition = _mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector2 aimDirection = mousePosition - _rb.position;
            float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
            _rb.rotation = aimAngle;
            _mainCamera.transform.position = new Vector3(_rb.transform.position.x, _rb.transform.position.y, _mainCamera.transform.position.z);
        }

        public IEnumerator ShootDelay()
        {
            while(true)
            {
                if(_ammo.value != _ammo.minValue)
                {
                    _pool.GetFreeElement(_damage);
                    _ammo.value--;
                    ShootAnimate(true);
                }
                yield return new WaitForSeconds(_shootDelay);
            }
        }

        public IEnumerator Reload()
        {
            while(_ammo.value != _ammo.maxValue)
            {
                _ammo.value++;
                yield return new WaitForSeconds(_reloadTime);
            }
        }

        public void ShootAnimate(bool isShoot)
        {
            _characterAnimator.SetShoot(isShoot);
        }
    }
}