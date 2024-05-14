using System;
using Scellecs.Morpeh;
using UnityEngine;

namespace App.Scripts.ECS.Components
{
    [Serializable]
    public struct CollisionEventComponent : IComponent
    {
        public Collision2D collision;
        public Entity first;
        public Entity second;
    }
}