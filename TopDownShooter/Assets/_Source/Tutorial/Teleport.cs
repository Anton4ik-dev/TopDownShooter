using Services;
using UnityEngine;
using Zenject;

namespace Tutorial
{
    public class Teleport : MonoBehaviour
    {
        [SerializeField] private Transform _nextPart;
        [SerializeField] private LayerMask _characterLayer;

        private LayerService _layerService;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_layerService.CheckLayersEquality(collision.gameObject.layer, _characterLayer))
                collision.transform.position = _nextPart.position;
        }

        [Inject]
        public void Construct(LayerService layerService)
        {
            _layerService = layerService;
        }
    }
}