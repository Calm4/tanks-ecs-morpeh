using System;
using Scellecs.Morpeh;
using UnityEngine;
using UnityEngine.Serialization;

namespace App.Scripts.Components
{
    [Serializable]
    public struct VelocityComponent : IComponent {
        public Vector2 velocityValue;
        public float speed;
        public float movementNormalization;
    }
}
