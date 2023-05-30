using Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PauseView : MonoBehaviour
    {
        [SerializeField] private Game game;
        [SerializeField] private UISwitcher uISwitcher;

        [SerializeField] private GameObject mainPanel;

        [SerializeField] private Button mainMenuButton;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button pauseButton;
        [SerializeField] private Button continueButton;

        private void Start()
        {
            Bind();
        }

        private void Bind()
        {
            gameObject.SetActive(false);

            restartButton.onClick.AddListener(game.RestartLevel);
            pauseButton.onClick.AddListener(Pause);
            continueButton.onClick.AddListener(UnPause);
            mainMenuButton.onClick.AddListener(game.GoToMainMenu);
        }

        private void Pause()
        {
            game.StopTime();
            uISwitcher.TurnOnPanel(gameObject);
        }

        private void UnPause()
        {
            game.Continue();
            uISwitcher.TurnOnPanel(mainPanel);
        }
    }
}