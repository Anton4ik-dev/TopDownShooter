using CharacterSystem;
using Services;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Boosters
{
    public abstract class ABooster : MonoBehaviour
    {
        [SerializeField] protected int _scale;
        [SerializeField] private float _boostTime;
        [SerializeField] private bool _isToRefresh;
        [SerializeField] private SpriteRenderer _sprite;
        [SerializeField] private Collider2D _collider2D;
        [SerializeField] private LayerMask _characterLayer;

        private const float REFRESH_TIME = 10;

        [Inject]
        private LayerService _layerService;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(_layerService.CheckLayersEquality(collision.gameObject.layer, _characterLayer))
            {
                if(collision.TryGetComponent(out CharacterView characterView))
                {
                    AddBoost(characterView);
                    StartCoroutine(BoostTimer(characterView));
                    _sprite.enabled = false;
                    _collider2D.enabled = false;
                    if (_isToRefresh)
                        StartCoroutine(Refresher());
                }
            }
        }

        [Inject]
        public void Construct(LayerService layerService)
        {
            _layerService = layerService;
        }

        private IEnumerator BoostTimer(CharacterView characterView)
        {
            yield return new WaitForSeconds(_boostTime);
            RemoveBoost(characterView);
        }

        private IEnumerator Refresher()
        {
            yield return new WaitForSeconds(REFRESH_TIME);
            _sprite.enabled = true;
            _collider2D.enabled = true;
        }

        protected abstract void AddBoost(CharacterView characterView);
        protected abstract void RemoveBoost(CharacterView characterView);
    }
}