using App.Scripts.ECS.Components;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace App.Scripts.ECS.Systems
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(CollisionInitSystem))]
    public sealed class CollisionInitSystem : FixedUpdateSystem
    {
        private Filter _wallsFilter;
        private Filter _playerFilter;
        private Filter _bulletsFilter;

        public override void OnAwake()
        {
            _wallsFilter = World.Filter.With<WallComponent>().Without<CanCollideComponent>().Build();
            _playerFilter = World.Filter.With<PlayerComponent>().Without<CanCollideComponent>().Build();
            _bulletsFilter = World.Filter.With<BulletComponent>().Without<CanCollideComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            ProcessPlayer();
            ProcessBullets();
            ProcessWalls();
        }

        private void ProcessBullets()
        {
            foreach (var entity in _bulletsFilter)
            {
                ref BulletComponent bullet = ref entity.GetComponent<BulletComponent>();
                MakeCanCollide(entity, bullet.body.gameObject);
            }
        }

        private void ProcessPlayer()
        {
            foreach (var entity in _playerFilter)
            {
                ref PlayerComponent player = ref entity.GetComponent<PlayerComponent>();
                MakeCanCollide(entity, player.body.gameObject);
            }
        }


        private void ProcessWalls()
        {
            foreach (var entity in _wallsFilter)
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


        public static CollisionInitSystem Create()
        {
            return CreateInstance<CollisionInitSystem>();
        }
    }
}