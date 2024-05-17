using System;
using Scellecs.Morpeh;

namespace App.Scripts.ECS.Collision
{
    [Serializable]
    public struct CanCollideComponent : IComponent
    {
        public CollisionDetector detector;
    }
}