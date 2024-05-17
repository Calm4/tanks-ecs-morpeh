using System;
using Scellecs.Morpeh;
using UnityEngine;

namespace App.Scripts.ECS.Components
{
    [Serializable]
    public struct EnemyComponent : IComponent
    {
        public Transform transform;
    }
}