using CharacterSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private int _mainMenuId;
        [SerializeField] private int _thisLevelId;
        [SerializeField] private int _minLevelId;
        [SerializeField] private int _maxLevelId;
        [SerializeField] private InputListener _inputListener;

        public void StopTime()
        {
            _inputListener.Expose();
            Time.timeScale = 0;
        }
        public void Continue()
        {
            _inputListener.Bind();
            Time.timeScale = 1;
        }

        public void RestartLevel()
        {
            Continue();
            _inputListener.Expose();
            SceneManager.LoadScene(_thisLevelId);
        }

        public void GoToNextLevel()
        {
            Continue();
            _inputListener.Expose();
            int nextLevelId = Random.Range(_minLevelId, _maxLevelId);
            while(nextLevelId == _thisLevelId)
                nextLevelId = Random.Range(_minLevelId, _maxLevelId);
            SceneManager.LoadScene(nextLevelId);
        }

        public void GoToMainMenu()
        {
            Continue();
            _inputListener.Expose();
            SceneManager.LoadScene(_mainMenuId);
        }
    }
}