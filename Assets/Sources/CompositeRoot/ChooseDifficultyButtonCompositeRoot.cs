using Sources.LevelSettings;
using Sources.Views;
using UnityEngine;

namespace Sources.CompositeRoot
{
    [RequireComponent(typeof(ButtonView))]
    internal sealed class ChooseDifficultyButtonCompositeRoot : CompositeRoot
    {
        [SerializeField] private Difficulty _difficulty;
        [SerializeField] private CurrentDifficultyTextCompositeRoot _currentDifficultyTextCompositeRoot;

        private ButtonView _buttonView;

        private void OnDisable()
        {
            _buttonView.Clicked -= OnClicked;
        }

        public override void Compose()
        {
            _buttonView = GetComponent<ButtonView>();
            
            _buttonView.Init();
            _buttonView.Clicked += OnClicked;
        }

        private void OnClicked()
        {
            PlayerData.PlayerData.SetLevelSettings(_difficulty.ToString());
            
            _currentDifficultyTextCompositeRoot.Show();
        }
    }
}