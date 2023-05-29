using UnityEngine;

namespace UI
{
    public class UISwitcher : MonoBehaviour
    {
        [SerializeField] private GameObject startPanel;

        private static GameObject _activePanel;

        private void Start()
        {
            _activePanel = startPanel;
        }

        public void TurnOnPanel(GameObject panel)
        {
            _activePanel?.SetActive(false);
            _activePanel = panel;
            _activePanel.SetActive(true);
        }
    }
}