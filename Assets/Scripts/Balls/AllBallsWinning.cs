using System.Collections.ObjectModel;

namespace Balls
{
    public class AllBallsWinning : IWinning
    {
        public bool IsWin(ReadOnlyCollection<IColor> balls)
        {
            return balls.Count == 0;
        }
    }
}
