using System;
using Scellecs.Morpeh;

namespace App.Scripts.Components
{
    [Serializable]
    public struct HealthComponent : IComponent
    {
        public int maxHealth;
        public int currentHealth;
    }
}