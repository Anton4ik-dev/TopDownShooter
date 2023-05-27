using ScriptableObjects;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CharacterSystem
{
    public class CharacterActions
    {
        private Rigidbody2D _rb;
        private Camera _mainCamera;
        private CharacterAnimator _characterAnimator;
        private BulletPool _pool;
        private float _shootDelay;
        private int _health;
        private float _moveSpeed;

        public CharacterActions(Rigidbody2D rb, Camera mainCamera, CharacterAnimator characterAnimator, BulletPool bulletPool, CharacterDataSO characterDataSO)
        {
            _rb = rb;
            _mainCamera = mainCamera;
            _characterAnimator = characterAnimator;
            _pool = bulletPool;
            _shootDelay = characterDataSO.ShootDelay;
            _health = characterDataSO.Health;
            _moveSpeed = characterDataSO.MoveSpeed;
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
        }

        public IEnumerator ShootDelay()
        {
            while(true)
            {
                _pool.GetFreeElement();
                ShootAnimate(true);
                yield return new WaitForSeconds(_shootDelay);
            }
        }

        public int TakeDamage(int damage)
        {
            _health -= damage;
            if (_health < 0)
            {
                _characterAnimator.SetDead();
                _health = 0;
            }
            return _health;
        }

        public void ShootAnimate(bool isShoot)
        {
            _characterAnimator.SetShoot(isShoot);
        }
    }
}