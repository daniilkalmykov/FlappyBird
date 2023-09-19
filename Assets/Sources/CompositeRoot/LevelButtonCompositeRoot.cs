using Sources.Views;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sources.CompositeRoot
{
    [RequireComponent(typeof(ButtonView))]
    internal sealed class LevelButtonCompositeRoot : CompositeRoot
    {
        [SerializeField] private SceneName _sceneName;
        
        private ButtonView _buttonView;

        private void OnEnable()
        {
            if (_buttonView != null)
                _buttonView.Clicked += OnClicked;
        }

        private void OnDisable()
        {
            if (_buttonView != null)
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
            SceneManager.LoadScene(_sceneName.ToString());
        }
    }

    internal enum SceneName
    {
        MainMenu,
        Level
    }
}