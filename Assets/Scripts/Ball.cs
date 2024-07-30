using System;
using UnityEngine;

namespace Breakout
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private Vector2 InitialImpulse;
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private Rigidbody2D rigidbody2D;

        private bool isMoving;
        private Vector2 initialPosition;

        private void Awake()
        {
            isMoving = false;
            initialPosition = rectTransform.localPosition;
        }


        private void Update()
        {
            if (!isMoving)
            {
                if (Input.GetKey(KeyCode.Space)) 
                { 
                    isMoving = true;
                    rigidbody2D.AddForce(InitialImpulse);
                }
            }
        }

        public void ResetBall()
        {
            rectTransform.localPosition = Vector2.zero;
            isMoving = false;

            //Stop Moving/Translating
            rigidbody2D.velocity = Vector3.zero;

        }
    }
}