using System;

namespace Sources.HealthSystem
{
    public interface IHealth
    {
        event Action Died;
        
        void Die();
    }
}