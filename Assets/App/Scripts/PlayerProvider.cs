using System;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using UnityEngine;
using UnityEngine.Serialization;

namespace App.Scripts
{
    [AddComponentMenu("ECS/Components/" + nameof(PlayerComponent))]
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class PlayerProvider : MonoProvider<PlayerComponent> { }
    
    [Serializable]
    public struct PlayerComponent : IComponent 
    {
        public PlayerConfig config;
        public Rigidbody2D body;
        public Vector2 userTextOffset;
    }
}