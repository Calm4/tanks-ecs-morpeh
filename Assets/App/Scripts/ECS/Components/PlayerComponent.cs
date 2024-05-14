using System;
using App.Scripts.Components;
using Scellecs.Morpeh;
using UnityEngine;

namespace App.Scripts.ECS.Components
{
    [Serializable]
    public struct PlayerComponent : IComponent 
    {
        public VelocityComponent config;
        public Rigidbody2D body;
        public Vector2 userTextOffset;
    }
}