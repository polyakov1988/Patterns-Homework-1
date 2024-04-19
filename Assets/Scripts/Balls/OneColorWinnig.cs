using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Balls
{
    public class OneColorWinnig : IWinning
    {
        private readonly int _colorCount = Enum.GetValues(typeof(BallColor)).Length;
    
        public bool IsWin(ReadOnlyCollection<IColor> balls)
        {
            List<BallColor> colors = balls.Select(ball => ball.BallColor).Distinct().ToList();

            return colors.Count != _colorCount;
        }
    }
}