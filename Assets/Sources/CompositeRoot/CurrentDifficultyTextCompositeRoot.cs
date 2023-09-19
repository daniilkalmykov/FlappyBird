using System.Collections.Generic;
using Sources.LevelSettings;
using Sources.Utilities;
using UnityEngine;

namespace Sources.CompositeRoot
{
    [RequireComponent(typeof(GameText))]
    internal sealed class CurrentDifficultyTextCompositeRoot : CompositeRoot
    {
        private const string StartText = "Current difficulty: ";
        
        [SerializeField] private List<LevelSettings.LevelSettings> _levelSettings;
        
        private GameText _gameText;

        public override void Compose()
        {
            _gameText = GetComponent<GameText>();
            
            _gameText.Init();
            Show();
        }

        public void Show()
        {
            _gameText.Show(StartText + LevelSettingsGetter.Get(_levelSettings).Difficulty);
        }
    }
}