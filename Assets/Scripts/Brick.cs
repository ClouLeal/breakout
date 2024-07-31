using System;
using UnityEngine;

namespace Breakout
{
    public class Brick : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        [SerializeField] private int brickScore;
        public int BrickScore => brickScore;

        public Action<Brick> OnHit;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Hit();
        }

        private void Hit()
        {
            PlayBrickHitFX();

            OnHit?.Invoke(this);

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