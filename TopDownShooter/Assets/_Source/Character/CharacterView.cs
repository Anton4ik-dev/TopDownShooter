using TMPro;
using UnityEngine;
using Zenject;

namespace CharacterSystem
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _health;

        private CharacterActions _characterActions;

        public int MaxHealth
        {
            get => _characterActions.MaxHealth;
            set
            {
                _characterActions.MaxHealth = value;
                ChangeHealthView();
            }
        }

        public int Health
        {
            get => _characterActions.Health;
            set
            {
                _characterActions.Health = value;
                ChangeHealthView();
            }
        }

        public int Damage
        {
            get => _characterActions.Damage;
            set
            {
                _characterActions.Damage = value;
            }
        }

        public float MoveSpeed
        {
            get => _characterActions.MoveSpeed;
            set
            {
                _characterActions.MoveSpeed = value;
            }
        }

        [Inject]
        public void Construct(CharacterActions characterActions)
        {
            _characterActions = characterActions;
            ChangeHealthView();
        }

        private void ChangeHealthView()
        {
            _health.text = $"{Health}/{MaxHealth}";
        }
    }
}