using App.Scripts.ECS.Components;
using App.Scripts.ECS.Movement;
using App.Scripts.ECS.Player;
using Scellecs.Morpeh;
using UnityEngine;

namespace App.Scripts.ECS.Enemy
{
    public class EntityFactory
    {
        private readonly World _world;
        private PlayerConfig _playerConfig;
        private Entity _playerEntity;

        public EntityFactory(World world)
        {
            _world = world;
        }
  

        public Entity CreateEntityWithComponents()
        {
            _playerConfig = ScriptableObject.CreateInstance<PlayerConfig>();
            _playerConfig.speed = 4f;
        
            _playerEntity = _world.CreateEntity();
            ref PlayerComponent player = ref _playerEntity.AddComponent<PlayerComponent>();
            player.config = _playerConfig;
            player.body = new GameObject("PlayerObject").AddComponent<Rigidbody2D>();
            player.body.drag = 0;

            ref MoveDirectionComponent moveDirection = ref _playerEntity.AddComponent<MoveDirectionComponent>();
            moveDirection.direction = Vector2.zero;
   
            return _playerEntity;
        }

        public Entity CreateCameraEntity(Entity playerEntity)
        {
            var cameraEntity = _world.CreateEntity();
            ref var followTarget = ref cameraEntity.AddComponent<FollowTargetComponent>(out _);
            followTarget.TargetEntity = playerEntity;
            return cameraEntity;
        }
    }
}