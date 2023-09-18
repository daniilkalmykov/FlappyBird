using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Assembly-Csharp")]
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