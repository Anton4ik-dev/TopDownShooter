using Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class WinView : MonoBehaviour
    {
        [SerializeField] private Game game;

        [SerializeField] private Button mainMenuButton;
        [SerializeField] private Button nextLevelButton;

        private void Start()
        {
            Bind();
        }

        private void Bind()
        {
            gameObject.SetActive(false);

            nextLevelButton.onClick.AddListener(game.GoToNextLevel);
            mainMenuButton.onClick.AddListener(game.GoToMainMenu);
        }

        public void DrawWinPanel()
        {
            game.StopTime();
            gameObject.SetActive(true);
        }
    }
}