using TMPro;
using UnityEngine;
using Zenject;

namespace CharacterSystem
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _health;

        private CharacterActions _characterActions;

        public void TakeDamage(int damage)
        {
            _health.text = $"{_characterActions.TakeDamage(damage)}";
        }

        [Inject]
        public void Construct(CharacterActions characterActions)
        {
            _characterActions = characterActions;
        }
    }
}