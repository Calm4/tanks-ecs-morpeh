using System;
using Scellecs.Morpeh;

namespace App.Scripts.ECS.GameInput {

    [Serializable]
    public struct ControlledByUserComponent : IComponent {
        public Entity user;
    }
}