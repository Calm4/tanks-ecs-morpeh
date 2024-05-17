using System;
using Scellecs.Morpeh;

namespace App.Scripts.ECS.Player
{
    [Serializable]
    public struct UserWithPlayer : IComponent
    {
        public Entity player;
    }
}