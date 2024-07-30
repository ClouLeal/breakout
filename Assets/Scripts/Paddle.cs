using System;
using UnityEngine;

namespace Breakout
{
    public class Paddle : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidbody2D;
        [SerializeField] private float paddleSpeed;
        [SerializeField] private RectTransform rectTransform;

        private Vector2 direction;
        private Vector2 initialPosition;

        private void Awake()
        {
            initialPosition = rectTransform.position;
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                direction = Vector2.left;
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                direction = Vector2.right;
            }
            else
            {
                direction = Vector2.zero;
            }
        }

        private void FixedUpdate()
        {
            rigidbody2D.AddForce(direction * paddleSpeed);
        }


        public void ResetPaddle()
        {
            rectTransform.localPosition = Vector2.zero;

            //Stop Moving/Translating
            rigidbody2D.velocity = Vector3.zero;
        }
    }
}