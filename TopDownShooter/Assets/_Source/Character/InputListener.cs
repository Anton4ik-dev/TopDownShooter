using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace CharacterSystem
{
    public class InputListener : MonoBehaviour
    {
        private CharacterActions _characterActions;
        private MainInput _mainInput;

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

            _mainInput.Player.Move.performed -= Move;
            _mainInput.Player.Move.canceled -= Move;
        }

        public void Bind()
        {
            _mainInput.Player.Enable();

            _mainInput.Player.Shoot.performed += StartShoot;

            _mainInput.Player.Move.performed += Move;
            _mainInput.Player.Move.canceled += Move;
        }

        private void StartShoot(InputAction.CallbackContext context)
        {
            if(_characterActions.Ammo.value == _characterActions.Ammo.maxValue)
            {
                _characterActions.Shoot();
                StartCoroutine(_characterActions.Reload());
            }
        }

        private void Move(InputAction.CallbackContext context)
        {
            Vector2 direction = context.ReadValue<Vector2>();

            _characterActions.Move(direction.x, direction.y);
        }
    }
}