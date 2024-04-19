using System.Collections.ObjectModel;

namespace Balls
{
    public interface IWinning
    {
        bool IsWin(ReadOnlyCollection<IColor> balls);
    }
}