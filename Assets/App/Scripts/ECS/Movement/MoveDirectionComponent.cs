using System;
using Scellecs.Morpeh;
using UnityEngine;

namespace App.Scripts.ECS.Movement
{
    [Serializable]
    public struct MoveDirectionComponent : IComponent
    {
        public Vector2 direction;
    }
}