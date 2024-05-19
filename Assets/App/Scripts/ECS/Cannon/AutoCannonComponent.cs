using System;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using UnityEngine;

namespace App.Scripts.ECS.Cannon
{
    [AddComponentMenu("ECS/Components/" + nameof(AutoCannonComponent))]
    public sealed class AutoCannonProvider : MonoProvider<AutoCannonComponent> { }

    [Serializable]
    public struct AutoCannonComponent : IComponent
    {
        public CannonConfig config;
        public Rigidbody2D body; 
        public float lastShotTime;
        public bool canShoot;
    }
}