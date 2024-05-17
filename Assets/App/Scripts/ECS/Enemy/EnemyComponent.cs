using System;
using Scellecs.Morpeh;
using UnityEngine;

namespace App.Scripts.ECS.Enemy
{
    [Serializable]
    public struct EnemyComponent : IComponent
    {
        public Transform transform;
    }
}