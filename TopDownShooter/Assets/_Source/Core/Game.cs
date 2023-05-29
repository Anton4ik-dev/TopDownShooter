using CharacterSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private int mainMenuId;
        [SerializeField] private int thisLevelId;
        [SerializeField] private int nextLevelId;

        [SerializeField] private InputListener inputListener;

        public void StopTime()
        {
            Time.timeScale = 0;
            inputListener.Expose();
        }
        public void Continue()
        {
            Time.timeScale = 1;
            inputListener.Bind();
        }

        public void RestartLevel()
        {
            Continue();
            inputListener.Expose();
            SceneManager.LoadScene(thisLevelId);
        }

        public void GoToNextLevel()
        {
            Continue();
            inputListener.Expose();
            SceneManager.LoadScene(nextLevelId);
        }

        public void GoToMainMenu()
        {
            Continue();
            inputListener.Expose();
            SceneManager.LoadScene(mainMenuId);
        }
    }
}