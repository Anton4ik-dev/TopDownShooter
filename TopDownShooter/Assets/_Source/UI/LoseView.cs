using Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LoseView : MonoBehaviour
    {
        [SerializeField] private Game game;

        [SerializeField] private Button mainMenuButton;
        [SerializeField] private Button restartButton;

        private void Start()
        {
            Bind();
        }

        private void Bind()
        {
            gameObject.SetActive(false);

            restartButton.onClick.AddListener(game.RestartLevel);
            mainMenuButton.onClick.AddListener(game.GoToMainMenu);
        }

        public void DrawLosePanel()
        {
            game.StopTime();
            gameObject.SetActive(true);
        }
    }
}