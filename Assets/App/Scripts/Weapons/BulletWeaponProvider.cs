using System;
using App.Scripts.ECS.Components;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using UnityEngine;

namespace App.Scripts.Weapons
{
    [AddComponentMenu("ECS/Components/" + nameof(BulletWeaponComponent))]
    
    public sealed class BulletWeaponProvider : MonoProvider<BulletWeaponComponent> { }

    [Serializable]
    public struct BulletWeaponComponent : IComponent
    {
        public BulletWeaponConfig config;
        public bool shoot;
        public float lastShotTime;
    }
}