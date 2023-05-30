using Services;
using UnityEngine;
using Zenject;

namespace Tutorial
{
    public class TutorialClue : MonoBehaviour
    {
        [SerializeField] private GameObject _clue;
        [SerializeField] private LayerMask _characterLayer;

        private LayerService _layerService;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_layerService.CheckLayersEquality(collision.gameObject.layer, _characterLayer))
                _clue.SetActive(true);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (_layerService.CheckLayersEquality(collision.gameObject.layer, _characterLayer))
                _clue.SetActive(false);
        }

        [Inject]
        public void Construct(LayerService layerService)
        {
            _layerService = layerService;
        }
    }
}