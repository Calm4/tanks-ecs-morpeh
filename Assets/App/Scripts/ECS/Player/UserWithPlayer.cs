using System;
using Scellecs.Morpeh;

namespace App.Scripts
{
    [Serializable]
    public struct UserWithPlayer : IComponent
    {
        public Entity player;
    }
}