using Services;
using UI;
using UnityEngine;
using Zenject;

namespace Clues
{
    public class Computer : MonoBehaviour
    {
        [SerializeField] private WinView _winView;
        [SerializeField] private LayerMask _characterLayer;

        private bool _isBossDead;
        private LayerService _layerService;

        public bool IsBossDead
        {
            get => _isBossDead;
            set
            {
                _isBossDead = value;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_layerService.CheckLayersEquality(collision.gameObject.layer, _characterLayer) && _isBossDead)
                _winView.DrawWinPanel();
        }

        [Inject]
        public void Construct(LayerService layerService)
        {
            _layerService = layerService;
        }
    }
}