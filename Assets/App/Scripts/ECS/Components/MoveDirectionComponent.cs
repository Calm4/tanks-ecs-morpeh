using System;
using Scellecs.Morpeh;
using UnityEngine;

namespace App.Scripts.ECS.Components
{
    [Serializable]
    public struct MoveDirectionComponent : IComponent
    {
        public Vector2 direction;
    }
}