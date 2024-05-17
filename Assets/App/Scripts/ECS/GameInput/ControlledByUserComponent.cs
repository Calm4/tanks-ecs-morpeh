using System;
using Scellecs.Morpeh;

namespace App.Scripts.ECS.Components {

    [Serializable]
    public struct ControlledByUserComponent : IComponent {
        public Entity user;
    }
}