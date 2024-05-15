using System;
using Scellecs.Morpeh;

namespace App.Scripts.ECS.Components
{
    [Serializable]
    public struct HealthComponent : IComponent
    {
        public int maxHealth;
        public int currentHealth;
    }
}