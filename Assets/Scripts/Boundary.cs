using UnityEngine;

namespace Breakout
{
    public class Boundary : MonoBehaviour
    {
        [SerializeField] private BoxCollider2D BoxCollider2D;
        //[SerializeField] private bool IsDeadZone;

        private void Start() =>
            BoxCollider2D.size = (transform as RectTransform).rect.size;

       /* private void OnCollisionEnter2D(Collision2D collision)
        {
            if (IsDeadZone) 
            {
                GameManager.Instance.LoseLife();
            }
        }*/
    }
}
