using System;
using UnityEngine;

namespace Breakout
{
    public class Brick : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private int brickScore;
        [SerializeField] private Collider2D collider;

        public int BrickScore => brickScore;

        public Action<Brick> OnHit;

        private const string sfxHitBrick = "HitBrick";
        private const string animHiBrick = "BallHit";

        private void OnEnable()
        {
            collider.enabled = true;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Hit();
        }

        private void Hit()
        {
            PlayBrickHitFX();

            OnHit?.Invoke(this);

            //Avoid ball hit block while on animation
            collider.enabled = false;

            //This will make if loos all listenners references because this is a brocke brick
            OnHit = null;
        }

        private void PlayBrickHitFX()
        {
            animator.SetTrigger(animHiBrick);

            AudioManager.Instance.Play(sfxHitBrick);

            Invoke("DesableBrick", 1f);
        }

        private void DesableBrick()
        {
            this.gameObject.SetActive(false);
            OnHit = null;
        }
    }

    
}