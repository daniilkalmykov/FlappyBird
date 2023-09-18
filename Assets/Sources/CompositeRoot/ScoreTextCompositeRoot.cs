using Sources.Utilities;
using UnityEngine;

namespace Sources.CompositeRoot
{
    [RequireComponent(typeof(GameText))]
    internal sealed class ScoreTextCompositeRoot : CompositeRoot
    {
        [SerializeField] private BirdCompositeRoot _birdCompositeRoot;
        
        private GameText _gameText;

        private void OnDisable()
        {
            _birdCompositeRoot.Score.PointsChanged -= OnPointsChanged;
        }

        public override void Compose()
        {
            _gameText = GetComponent<GameText>();
            
            _gameText.Init();
            _gameText.Show(_birdCompositeRoot.Score.PointsCount.ToString());
            
            _birdCompositeRoot.Score.PointsChanged += OnPointsChanged;
        }

        private void OnPointsChanged()
        {
            _gameText.Show(_birdCompositeRoot.Score.PointsCount.ToString());
        }
    }
}