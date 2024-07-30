using TMPro;
using UnityEngine;

namespace Breakout
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreTxt;
        [SerializeField] private TMP_Text livesTxt;

        public void UpdateScore(int score)
        {
            scoreTxt.text = "Score: " + score;
        }

        public void UpdateLives(int lives)
        {
            livesTxt.text = "Lives: " + lives.ToString();
        }

    }
}
