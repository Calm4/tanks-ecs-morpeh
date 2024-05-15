using App.Scripts;
using App.Scripts.Components;
using App.Scripts.ECS.Components;
using App.Scripts.Weapons;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using UnityEngine;
using HealthComponent = App.Scripts.HealthComponent;

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
        player.body = new GameObject().AddComponent<Rigidbody2D>();
        player.body.drag = 0;

        ref MoveDirectionComponent moveDirection = ref _playerEntity.AddComponent<MoveDirectionComponent>();
        moveDirection.direction = Vector2.zero;
        
        /*ref var playerGameObject = ref entity.AddComponent<GameObjectComponent>();
        playerGameObject.GameObject = new GameObject("Player");*/
        

        /*ref var spriteRenderer = ref entity.AddComponent<SpriteRendererComponent>();
        spriteRenderer.SpriteRenderer = player.body.gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.SpriteRenderer.sprite = sprite;*/
        
        /*ref var canCollideComponent = ref entity.AddComponent<CanCollideComponent>();
        canCollideComponent.detector = playerGameObject.GameObject.AddComponent<CollisionDetector>();
        canCollideComponent.detector.Init(_world);
        canCollideComponent.detector.listener = entity;*/
         
        /*
        ref var bulletWeaponComponent = ref entity.AddComponent<BulletWeaponComponent>();
        bulletWeaponComponent.config = bulletWeaponConfig;*/
        return _playerEntity;
    }

    public Entity CreateEnemyEntity(Sprite sprite)
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

        enemyGameObject.GameObject.AddComponent<BoxCollider2D>();

        enemyGameObject.GameObject.AddComponent<PlayerCollision>();

        enemyGameObject.GameObject.AddComponent<EntityProvider>();

        return entity;
    }

    public Entity CreateCameraEntity(Entity playerEntity)
    {
        var cameraEntity = _world.CreateEntity();
        ref var followTarget = ref cameraEntity.AddComponent<FollowTargetComponent>(out _);
        followTarget.TargetEntity = playerEntity;
        return cameraEntity;
    }
}