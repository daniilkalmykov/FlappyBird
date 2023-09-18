namespace Sources.ScoreSystem
{
    internal sealed class Score : IScore
    {
        public float PointsCount { get; private set; }

        public void Increase()
        {
            PointsCount++;
        }
    }
}