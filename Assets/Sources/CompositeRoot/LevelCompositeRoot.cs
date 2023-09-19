using Sources.LevelSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.CompositeRoot
{
    internal sealed class LevelCompositeRoot : CompositeRoot
    {
        [SerializeField] private BirdCompositeRoot _birdCompositeRoot;
        [SerializeField] private Image _deathScreen;
        
        private Level _level;

        private void OnDisable()
        {
            _level.Ended -= OnEnded;
        }

        public override void Compose()
        {
            _level = new Level(_birdCompositeRoot.Health);
            
            _level.Start();
            _level.Ended += OnEnded;

            Time.timeScale = 1;
            _deathScreen.gameObject.SetActive(false);
        }

        private void OnEnded()
        {
            _deathScreen.gameObject.SetActive(true);

            Time.timeScale = 0;
        }
    }
}