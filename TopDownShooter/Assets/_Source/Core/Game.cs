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
            inputListener.Expose();
            Time.timeScale = 0;
        }
        public void Continue()
        {
            inputListener.Bind();
            Time.timeScale = 1;
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