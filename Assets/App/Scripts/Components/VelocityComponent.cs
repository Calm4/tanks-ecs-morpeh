using System;
using Scellecs.Morpeh;
using UnityEngine;

namespace App.Scripts.Components
{
    [Serializable]
    public struct VelocityComponent : IComponent {
        public Vector2 VelocityValue;
        public float Speed;
    }
}
