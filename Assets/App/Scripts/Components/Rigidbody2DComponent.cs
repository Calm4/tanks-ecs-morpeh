using System;
using Scellecs.Morpeh;
using UnityEngine;

namespace App.Scripts.Components
{
    [Serializable]
    public struct Rigidbody2DComponent : IComponent
    {
        public Rigidbody2D Rigidbody;
    }
}