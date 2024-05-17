using System;
using Scellecs.Morpeh;
using UnityEngine;

namespace App.Scripts.ECS.Weapons
{
    [Serializable]
    public struct BulletComponent : IComponent
    {
        public BulletConfig config;
        public Rigidbody2D body;
        public Entity shooter;
    }
}