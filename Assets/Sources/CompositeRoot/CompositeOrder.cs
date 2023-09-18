using UnityEngine;

namespace Sources.CompositeRoot
{
    internal sealed class CompositeOrder : MonoBehaviour
    {
        [SerializeField] private BirdCompositeRoot _birdCompositeRoot;
        [SerializeField] private ScoreTextCompositeRoot _scoreTextCompositeRoot;

        private void Awake()
        {
            _birdCompositeRoot.Compose();
            _scoreTextCompositeRoot.Compose();
        }
    }
}