using App.Scripts.ECS.Components;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace App.Scripts.ECS.Systems
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(CollisionInitSystem))]
    public sealed class CollisionInitSystem : FixedUpdateSystem
    {
        private Filter wallsFilter;
        public override void OnAwake()
        {
            wallsFilter = World.Filter.With<WallComponent>().Without<CanCollideComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            ProcessWalls();
        }

        private void ProcessWalls()
        {
            foreach (var entity in wallsFilter)
            {
                ref WallComponent wall = ref entity.GetComponent<WallComponent>();
                MakeCanCollide(entity, wall.transform.gameObject);
            }
        }

        private void MakeCanCollide(Entity entity, GameObject go)
        {
            ref CanCollideComponent canCollide = ref entity.AddComponent<CanCollideComponent>();

            canCollide.detector = go.AddComponent<CollisionDetector>();
            canCollide.detector.Init(World);
            canCollide.detector.listener = entity;
        }
        
        public static CollisionInitSystem Create() {
            return CreateInstance<CollisionInitSystem>();
        }
    }
}