using System;
using Scellecs.Morpeh;

namespace App.Scripts.ECS.Health
{
    [Serializable]
    public struct DamageComponent : IComponent
    {
        public int Damage;
        public int CritDamage;
    }
}