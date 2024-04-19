using System.Collections.ObjectModel;
using UnityEngine;

namespace Balls
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private BallSpawner _ballSpawner;
        [SerializeField] private CanvasGroup _buttons;
        [SerializeField] private CanvasGroup _win;

        private IWinning _winning;

        private void OnEnable()
        {
            _ballSpawner.BallsCountChanged += CheckWinning;
        }
    
        private void OnDisable()
        {
            _ballSpawner.BallsCountChanged -= CheckWinning;
        }

        public void SetAllBallsWinning()
        {
            _winning = new AllBallsWinning();
            StartGame();
        }
    
        public void SetOneColorWinning()
        {
            _winning = new OneColorWinnig();
            StartGame();
        }

        private void StartGame()
        {
            _buttons.alpha = 0;
            _buttons.blocksRaycasts = false;
            _ballSpawner.Spawn();
        }

        private void CheckWinning(ReadOnlyCollection<IColor> balls)
        {
            if (_winning.IsWin(balls))
            {
                _win.alpha = 1;
            }
        }
    }
}