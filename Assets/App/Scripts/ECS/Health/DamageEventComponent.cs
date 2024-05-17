using System;
using JetBrains.Annotations;
using Scellecs.Morpeh;
using UnityEngine;

namespace App.Scripts.ECS.Components
{
    [Serializable]
    public struct DamageEventComponent : IComponent
    {
        public Vector3? hitPosition;
        public int amount;
        [CanBeNull] public Entity dealer;
    }
}