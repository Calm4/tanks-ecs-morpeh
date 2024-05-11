using System;
using Scellecs.Morpeh;
using UnityEngine;
using UnityEngine.Serialization;

namespace App.Scripts.Components
{
    [Serializable]
    public struct FollowTargetComponent : IComponent
    {
        public Entity TargetEntity;
    }
}