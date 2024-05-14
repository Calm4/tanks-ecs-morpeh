using App.Scripts;
using App.Scripts.Components;
using App.Scripts.ECS.Components;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using UnityEngine;
using HealthComponent = App.Scripts.HealthComponent;

public class EntityFactory
{
    private World _world;

    public EntityFactory(World world)
    {
        _world = world;
    }

    public Entity CreateEntityWithComponents(Sprite sprite, float speed, float movementNormalization)
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

      

        playerGameObject.GameObject.AddComponent<BoxCollider2D>();

        ref var canCollideComponent = ref entity.AddComponent<CanCollideComponent>();
        canCollideComponent.detector = playerGameObject.GameObject.AddComponent<CollisionDetector>();
        canCollideComponent.detector.Init(_world);
        canCollideComponent.detector.listener = entity;
        
        return entity;
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