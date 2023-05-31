using System.Collections;
using UnityEngine;

namespace Clues
{
    public class CharacterMessage : MonoBehaviour
    {
        [SerializeField] private GameObject _message;
        [SerializeField] private float _duration;

        private void Start()
        {
            StartCoroutine(HideMessage());
        }

        private IEnumerator HideMessage()
        {
            yield return new WaitForSeconds(_duration);
            _message.SetActive(false);
        }
    }
}