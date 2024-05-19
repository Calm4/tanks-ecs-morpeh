using System;
using App.Scripts.ECS.Weapons;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using UnityEngine;
using UnityEngine.Serialization;

namespace App.Scripts.ECS.Cannon
{
    [AddComponentMenu("ECS/Components/" + nameof(AutoCannonComponent))]
    public sealed class AutoCannonProvider : MonoProvider<AutoCannonComponent>
    {
    }

    [Serializable]
    public struct AutoCannonComponent : IComponent
    {
        public BulletWeaponConfig config;
        public Rigidbody2D body;
        public float lastShotTime;
        public Transform shootPoint;
    }
}