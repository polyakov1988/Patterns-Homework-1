using System;
using UnityEngine;

namespace Balls
{
    public class Ball : MonoBehaviour, IColor
    {
        [SerializeField] private Renderer _renderer;

        public event Action<Ball> Destroyed;
    
        public BallColor BallColor { get; private set; }

        public void Init(BallColor ballColor, Color materialColor, Vector3 scale)
        {
            BallColor = ballColor;
            _renderer.material.color = materialColor;
            transform.localScale = scale;
        }

        private void OnMouseDown()
        {
            Destroyed?.Invoke(this);
        }
    }
}
