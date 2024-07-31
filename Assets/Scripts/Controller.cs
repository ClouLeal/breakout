using UnityEngine;

using System.Linq;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;

namespace Breakout
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] private Brick BrickPrefab;
        [SerializeField] private Transform BrickContainer;

        List<Brick> bricksList = new List<Brick>();

        int hitBrickCount = 0;

        private void Awake()
        {
            GetBricksRefernces();
        }

         private void GetBricksRefernces()
        {
            foreach (Transform brickObject in BrickContainer)
            {
                if (brickObject.gameObject.TryGetComponent<Brick>(out var brick))
                {
                    bricksList.Add(brick);
                }
            }
        }

        private void HitBrickHandler(Brick brick)
        {
            hitBrickCount++;
            brick.OnHit = null;

            if(hitBrickCount >= bricksList.Count)
            {
                GameManager.Instance.GameOver();
            }
            else
            {
                GameManager.Instance.OnBrickHit(brick.BrickScore);
            }
        }

        public void SetUpNewGame()
        {
            foreach (var brick in bricksList)
            {
                brick.gameObject.SetActive(true);
                brick.OnHit += HitBrickHandler;
            }
        }

        internal void SetGameOver()
        {
            foreach (var brick in bricksList)
            {
                brick.gameObject.SetActive(false);
                brick.OnHit = null;
            }
        }

        
    }
}