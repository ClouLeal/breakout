using UnityEngine;
using UnityEngine.Events;

namespace Breakout
{ 
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [SerializeField] Controller controller;

        public int score = 0;
        public int lives = 3;

        public UnityEvent<int> UpdateScore;
        public UnityEvent<int> UpdateLife;

        public UnityEvent ResetGameState;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }

            DontDestroyOnLoad(gameObject);
        }

        void Start()
        {
            NewGame();
        }


        public void NewGame()
        {
            this.score = 0;
            this.lives = 3;

            controller.SetUpNewGame();

            ResetPosition();


            UpdateScore.Invoke(score);
            UpdateLife.Invoke(lives);
        }


        public void OnBrickHit(int points)
        {
            this.score += points;

            UpdateScore?.Invoke(score);
        }


        public void LoseLife()
        {
            lives--;
            UpdateLife.Invoke(lives);

            if (lives == 0)
            {
               Invoke("GameOver", 0.1f);
            }
            else
            {
                Invoke("ResetPosition", 0.3f);
            }
        }

        private void ResetPosition()
        {
            ResetGameState?.Invoke();
        }

        public void GameOver()
        {
            controller.SetGameOver();
            Invoke("NewGame", 1f);
        }
    }
}
