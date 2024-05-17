using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using UnityEngine;

namespace App.Scripts.ECS.Cannon
{
    [AddComponentMenu("ECS/Components/CannonComponent")]
    public sealed class CannonProvider : MonoProvider<CannonComponent> { }

    public struct CannonComponent : IComponent
    {
        public CannonConfig config;
        public Rigidbody2D body;
    }
}