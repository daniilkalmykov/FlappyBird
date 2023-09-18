using UnityEngine;

namespace Sources.CompositeRoot
{
    internal sealed class CompositeOrder : MonoBehaviour
    {
        [SerializeField] private BirdCompositeRoot _birdCompositeRoot;

        private void Awake()
        {
            _birdCompositeRoot.Compose();
        }
    }
}