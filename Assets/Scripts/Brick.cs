using System;
using UnityEngine;

namespace Breakout
{
    public class Brick : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        [SerializeField] int brickScore;

        public Action<int> OnHit;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Hit();
        }

        private void Hit()
        {
            PlayBrickHitFX();

            OnHit?.Invoke(brickScore);

            //This will make if loos all listenners references because this is a brocke brick
            OnHit = null;
        }

        private void PlayBrickHitFX()
        {
            animator.SetTrigger("BallHit");

            Invoke("DesableBrick", 1f);
        }

        private void DesableBrick()
        {
            this.gameObject.SetActive(false);
        }
    }

    
}