using System;

namespace Sources.HealthSystem
{
    internal sealed class Health : IHealth
    {
        public event Action Died;
        
        public void Die()
        {
            Died?.Invoke();
        }
    }
}