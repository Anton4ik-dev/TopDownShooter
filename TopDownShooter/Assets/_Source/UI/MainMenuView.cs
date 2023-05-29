using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private int firstLevelId;

        private void Start()
        {
            Bind();
        }

        private void Bind()
        {
            startButton.onClick.AddListener(() => SceneManager.LoadScene(firstLevelId));
        }
    }
}