using System;
using Scellecs.Morpeh;
using UnityEngine;

namespace App.Scripts.Components
{
    [Serializable]
    public struct GameObjectComponent : IComponent {
        public GameObject GameObject;
    }
}
