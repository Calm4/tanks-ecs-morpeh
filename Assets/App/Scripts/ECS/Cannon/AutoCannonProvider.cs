using System;
using App.Scripts.ECS.Weapons;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using UnityEngine;
using UnityEngine.Serialization;

namespace App.Scripts.ECS.Cannon
{
    [AddComponentMenu("ECS/Components/" + nameof(BulletWeaponComponent))]
    public sealed class AutoCannonProvider : MonoProvider<BulletWeaponComponent> { }

    [Serializable]
    public struct BulletWeaponComponent : IComponent
    {
        public BulletWeaponConfig config;
        public Rigidbody2D body;
        public float lastShotTime;
         public Transform shootPoint;
    }
}