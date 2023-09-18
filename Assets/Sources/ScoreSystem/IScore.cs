using System;

namespace Sources.ScoreSystem
{
    public interface IScore
    {
        event Action PointsChanged;
        
        int PointsCount { get; }
    }
}