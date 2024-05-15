using Scellecs.Morpeh.Systems;
using UnityEngine;
using Scellecs.Morpeh;

namespace App.Scripts
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(PhysicsUpdateSystem), fileName = "Physics Update System")]
    public sealed class PhysicsUpdateSystem : FixedUpdateSystem
    {
        public override void OnAwake()
        {
        }

        public override void OnUpdate(float deltaTime)
        {
            Simulate(deltaTime);
        }

        public static void Simulate(float dt)
        {
            Physics2D.Simulate(dt);
        }
    }
}