using System;
using Scellecs.Morpeh;

namespace App.Scripts.ECS.Components
{
    [Serializable]
    public struct CanCollideComponent : IComponent
    {
        public CollisionDetector detector;
    }
}