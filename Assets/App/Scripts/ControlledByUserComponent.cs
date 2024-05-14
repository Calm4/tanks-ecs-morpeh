using System;
using Scellecs.Morpeh;

namespace App.Scripts {

    [Serializable]
    public struct ControlledByUserComponent : IComponent {
        public Entity user;
    }
}