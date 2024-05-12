using App.Scripts.Components;
using App.Scripts.Systems;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using UnityEngine;

namespace App.Scripts
{
    public class Game : MonoBehaviour
    { 
        [SerializeField] private Sprite sprite;
        [SerializeField] private float speed;
        [SerializeField] private float movementNormalization;
        private World _world;
        private MovementSystem _movementSystem;
        private CameraFollowSystem _cameraFollowSystem;
        private HealthSystem _healthSystem;
        private EnemyHealthSystem _enemyHealthSystem;
        private Entity _playerEntity;
        private Entity _enemyEntity;
        void Start()
        {
            _world = World.Default;
        
            _movementSystem = new MovementSystem { World = _world };
            _cameraFollowSystem = new CameraFollowSystem { World = _world };
            _healthSystem = new HealthSystem() { World = _world };
            _enemyHealthSystem = new EnemyHealthSystem() { World = _world };
        
            var systemsGroup = _world.CreateSystemsGroup();
            systemsGroup.AddSystem(_movementSystem);
            systemsGroup.AddSystem(_cameraFollowSystem);
            systemsGroup.AddSystem(_healthSystem);
            systemsGroup.AddSystem(_enemyHealthSystem);
        
            _world.AddPluginSystemsGroup(systemsGroup);
            _playerEntity = CreateEntityWithComponents();
            _enemyEntity = CreateEnemyEntity();
            CreateCameraEntity();
        }

        private Entity CreateEntityWithComponents()
        {
            var entity = _world.CreateEntity();
            entity.AddComponent<PlayerComponent>();
        
            ref var position = ref entity.AddComponent<PositionComponent>();
            position.PositionValue = Vector2.zero;
        
            ref var velocity = ref entity.AddComponent<VelocityComponent>();
            velocity.velocityValue = Vector2.zero;
            velocity.speed = speed;
            velocity.movementNormalization = movementNormalization;
        
            ref var playerGameObject = ref entity.AddComponent<GameObjectComponent>();
            playerGameObject.GameObject = new GameObject("Player");
        
            ref var spriteRenderer = ref entity.AddComponent<SpriteRendererComponent>();
            spriteRenderer.SpriteRenderer = playerGameObject.GameObject.AddComponent<SpriteRenderer>();
            spriteRenderer.SpriteRenderer.sprite = sprite;
        
            var rigidbody2d = playerGameObject.GameObject.AddComponent<Rigidbody2D>();
            rigidbody2d.freezeRotation = true;
            rigidbody2d.gravityScale = 0f;
            rigidbody2d.interpolation = RigidbodyInterpolation2D.Interpolate;
        
            ref var health = ref entity.AddComponent<HealthComponent>();
            health.currentHealth = 80;
            health.maxHealth = 100;

            ref var damage = ref entity.AddComponent<DamageComponent>();
            damage.Damage = 5;
            damage.CritDamage = 10;

            playerGameObject.GameObject.AddComponent<BoxCollider2D>();
            
            
        
            return entity;
        }
        private Entity CreateEnemyEntity()
        {
            var entity = _world.CreateEntity();
            entity.AddComponent<EnemyComponent>();

            ref var position = ref entity.AddComponent<PositionComponent>();
            position.PositionValue = new Vector2(4, 0);

            ref var enemyGameObject = ref entity.AddComponent<GameObjectComponent>();
            enemyGameObject.GameObject = new GameObject("Enemy");
    
            
            ref var spriteRenderer = ref entity.AddComponent<SpriteRendererComponent>();
            spriteRenderer.SpriteRenderer = enemyGameObject.GameObject.AddComponent<SpriteRenderer>();
            spriteRenderer.SpriteRenderer.sprite = sprite;
            spriteRenderer.SpriteRenderer.color = Color.red;    
            
            var rigidbody2d = enemyGameObject.GameObject.AddComponent<Rigidbody2D>();
            rigidbody2d.freezeRotation = true;
            rigidbody2d.gravityScale = 0f;
            rigidbody2d.interpolation = RigidbodyInterpolation2D.Interpolate;

            ref var health = ref entity.AddComponent<HealthComponent>();
            health.currentHealth = 100;
            health.maxHealth = 100;

            ref var damage = ref entity.AddComponent<DamageComponent>();
            damage.Damage = 5;
            damage.CritDamage = 10;
            
            enemyGameObject.GameObject.AddComponent<BoxCollider2D>();

            enemyGameObject.GameObject.AddComponent<PlayerCollision>();
            
            enemyGameObject.GameObject.AddComponent<EntityProvider>();
            
            return entity;
        }

        void CreateCameraEntity()
        {
            var cameraEntity = _world.CreateEntity();
            ref var followTarget = ref cameraEntity.AddComponent<FollowTargetComponent>(out _);
            followTarget.TargetEntity = _playerEntity;
        }


    }
}
