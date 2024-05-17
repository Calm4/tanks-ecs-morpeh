using System;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using UnityEngine;

namespace App.Scripts
{
    [AddComponentMenu("ECS/Components/HealthComponent")]
    public sealed class HealthProvider : MonoProvider<HealthComponent> { }

    [Serializable]
    public struct HealthComponent : IComponent
    {
        public int currentHealth;
        public int maxHealth;
    }
}