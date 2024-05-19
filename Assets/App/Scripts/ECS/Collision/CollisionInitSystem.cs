using App.Scripts.ECS.Cannon;
using App.Scripts.ECS.Player;
using App.Scripts.ECS.Wall;
using App.Scripts.ECS.Weapons;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using BulletWeaponComponent = App.Scripts.ECS.Cannon.BulletWeaponComponent;

namespace App.Scripts.ECS.Collision
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(CollisionInitSystem), fileName = "Collision Init System")]
    public sealed class CollisionInitSystem : FixedUpdateSystem
    {
        private Filter _wallsFilter;
        private Filter _playerFilter;
        private Filter _bulletsFilter;
        private Filter _cannonFilter;

        public override void OnAwake()
        {
            _wallsFilter = World.Filter.With<WallComponent>().Without<CanCollideComponent>().Build();
            _playerFilter = World.Filter.With<PlayerComponent>().Without<CanCollideComponent>().Build();
            _bulletsFilter = World.Filter.With<BulletComponent>().Without<CanCollideComponent>().Build();
            _cannonFilter = World.Filter.With<BulletWeaponComponent>().Without<CanCollideComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            ProcessPlayer();
            ProcessBullets();
            ProcessWalls();
            ProcessCannons();
        }

        private void ProcessCannons()
        {
            foreach (var entity in _cannonFilter)
            {
                ref BulletWeaponComponent cannon = ref entity.GetComponent<BulletWeaponComponent>();
                MakeCanCollide(entity, cannon.body.gameObject);
            }
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