using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Assembly-Csharp")]
namespace Sources.ScoreSystem
{
    internal sealed class Score : IScore
    {
        public event Action PointsChanged;
        
        public int PointsCount { get; private set; }

        public void Increase()
        {
            PointsCount++;

            PointsChanged?.Invoke();
        }
    }
}