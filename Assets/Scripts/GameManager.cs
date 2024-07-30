using UnityEngine;

namespace Breakout
{ 
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [SerializeField] Transform BricksContainer;
        [SerializeField] UIManager uiManager;
        [SerializeField] Ball ball;
        [SerializeField] Paddle paddle;
        [SerializeField] Controller controller;

        public int score = 0;
        public int lives = 3;


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


        void NewGame()
        {
            this.score = 0;
            this.lives = 3;

            controller.SetUpNewGame(HandleBrickHit);

            ResetPosition();

            uiManager.UpdateScore(score);
            uiManager.UpdateLives(lives);

        }


        void HandleBrickHit(int points)
        {
            this.score += points;

            uiManager.UpdateScore(score);
        }


        public void LoseLife()
        {
            lives--;
            uiManager.UpdateLives(lives);

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

            ball.ResetBall();
            paddle.ResetPaddle();
        }

        private void GameOver()
        {
            controller.SetGameOver();
            Invoke("NewGame", 1f);
        }
    }
}
