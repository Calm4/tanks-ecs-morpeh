using System;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using UnityEngine;

namespace App.Scripts
{
    [AddComponentMenu("ECS/Components/WallComponent")]
    public sealed class WallProvider : MonoProvider<WallComponent> { }
    
    [Serializable]
    public struct WallComponent : IComponent
    {
        public Transform transform;
    }
}