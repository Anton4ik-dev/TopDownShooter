using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace CharacterSystem
{
    public class InputListener : MonoBehaviour
    {
        private CharacterActions _characterActions;
        private MainInput _mainInput;
        private Coroutine _activeCoroutine;

        private void Update()
        {
            _characterActions.Rotate();
        }

        [Inject]
        public void Construct(CharacterActions characterActions)
        {
            _characterActions = characterActions;
            _mainInput = new MainInput();
            Bind();
        }

        public void Expose()
        {
            _mainInput.Player.Disable();

            _mainInput.Player.Shoot.performed -= StartShoot;
            _mainInput.Player.Shoot.canceled -= StopShoot;

            _mainInput.Player.Move.performed -= Move;
            _mainInput.Player.Move.canceled -= Move;
        }

        private void Bind()
        {
            _mainInput.Player.Enable();

            _mainInput.Player.Shoot.performed += StartShoot;
            _mainInput.Player.Shoot.canceled += StopShoot;

            _mainInput.Player.Move.performed += Move;
            _mainInput.Player.Move.canceled += Move;
        }

        private void StartShoot(InputAction.CallbackContext context)
        {
            _activeCoroutine = StartCoroutine(_characterActions.ShootDelay());
        }

        private void StopShoot(InputAction.CallbackContext context)
        {
            StopCoroutine(_activeCoroutine);
            _characterActions.ShootAnimate(false);
        }

        private void Move(InputAction.CallbackContext context)
        {
            Vector2 direction = context.ReadValue<Vector2>();

            _characterActions.Move(direction.x, direction.y);
        }
    }
}