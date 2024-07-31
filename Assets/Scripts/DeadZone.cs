using UnityEngine;

namespace Breakout
{
    public class DeadZone : Boundary
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            GameManager.Instance.LoseLife();
        }
       
    }
}
