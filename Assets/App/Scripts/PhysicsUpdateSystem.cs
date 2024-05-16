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
            Physics2D.simulationMode = SimulationMode2D.Script;
        }

        public override void OnUpdate(float deltaTime)
        {
            Simulate(deltaTime);
        }

        private static void Simulate(float dt)
        {
            Physics2D.Simulate(dt);
        }
    }
}