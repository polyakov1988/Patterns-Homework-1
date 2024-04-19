using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Balls
{
    public class BallSpawner : MonoBehaviour
    {
        [SerializeField] private Ball _ball;
        [SerializeField] private int _ballsCount;
        [SerializeField] private float _minSCale;
        [SerializeField] private float _maxSCale;
        [SerializeField] private float _minOffset;
        [SerializeField] private float _maxOffset;
    
        private List<IColor> _balls = new();
        private Dictionary<BallColor, Color> _ballColors;
        private WaitForSeconds _ballSpawnTime = new(0.2f);

        public event Action<ReadOnlyCollection<IColor>> BallsCountChanged;
    
        private void Awake()
        {
            _ballColors = new Dictionary<BallColor, Color>()
            {
                { BallColor.Green, Color.green }, 
                { BallColor.White, Color.white }, 
                { BallColor.Red, Color.red }
            };
        }

        public void Spawn()
        {
            StartCoroutine(SpawnBalls());
        }

        private IEnumerator SpawnBalls()
        {
            for (int i = 0; i < _ballsCount; i++)
            {
                foreach (var keyValuePair in _ballColors)
                {
                    float offsetX = Random.Range(_minOffset, _maxOffset);
                    float offsetZ = Random.Range(_minOffset, _maxOffset);

                    Vector3 position = new Vector3(offsetX, transform.position.y, offsetZ);
                
                    Ball ball = Instantiate(_ball, position, Quaternion.identity);

                    ball.Destroyed += RemoveBall;
                
                    ball.Init(keyValuePair.Key, keyValuePair.Value, Vector3.one * Random.Range(_minSCale, _maxSCale));
                
                    _balls.Add(ball);

                    yield return _ballSpawnTime;
                }
            }
        }

        private void RemoveBall(Ball ball)
        {
            ball.Destroyed -= RemoveBall;

            _balls.Remove(ball);
        
            Destroy(ball.gameObject);
        
            BallsCountChanged?.Invoke(_balls.AsReadOnly());
        }
    }
}