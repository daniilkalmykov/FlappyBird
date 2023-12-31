using System;
using System.Runtime.CompilerServices;
using Sources.HealthSystem;

[assembly: InternalsVisibleTo("Assembly-Csharp")]
namespace Sources.LevelSystem
{
    internal sealed class Level
    {
        private readonly IHealth _health;

        public Level(IHealth health)
        {
            _health = health ?? throw new ArgumentNullException();
        }

        public event Action Ended;
        
        public void Start()
        {
            _health.Died += OnDied;
        }

        public void End()
        {
            _health.Died -= OnDied;
        }
        
        private void OnDied()
        {
            Ended?.Invoke();
        }
    }
}