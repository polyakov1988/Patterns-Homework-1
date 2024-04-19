using System;
using UnityEngine;

namespace Traders
{
    public class Player : MonoBehaviour
    {
        private int _level;
        public event Action<int> LevelUp;

        private void Awake()
        {
            _level = 1;
        }

        private void Start()
        {
            LevelUp?.Invoke(_level);
        }

        public void AddLevel()
        {
            _level++;
            LevelUp?.Invoke(_level);
        }
    }
}

