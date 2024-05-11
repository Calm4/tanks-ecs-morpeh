using System;
using Scellecs.Morpeh;
using UnityEngine;

namespace App.Scripts.Components
{
    [Serializable]
    public struct SpriteRendererComponent : IComponent {
        public SpriteRenderer SpriteRenderer;
    }
}
