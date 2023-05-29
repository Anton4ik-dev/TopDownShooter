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
        [SerializeField] private SpriteRenderer _sprite;
        [SerializeField] private Collider2D _collider2D;
        [SerializeField] private LayerMask _characterLayer;

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

        protected abstract void AddBoost(CharacterView characterView);
        protected abstract void RemoveBoost(CharacterView characterView);
    }
}