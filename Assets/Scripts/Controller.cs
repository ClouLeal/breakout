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

        /*[SerializeField] int colunmSize = 5;
        [SerializeField] int rowSize = 3;*/

        List<Brick> bricksList = new List<Brick>();

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

        public void SetUpNewGame(Action<int> handleBrickHit)
        {
            foreach (var brick in bricksList)
            {
                brick.gameObject.SetActive(true);
                brick.OnHit += handleBrickHit;
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