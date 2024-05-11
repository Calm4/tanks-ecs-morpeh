using System.Collections;
using System.Collections.Generic;
using App.Scripts;
using App.Scripts.Components;
using App.Scripts.Systems;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Game : MonoBehaviour
{ 
    [SerializeField] private Sprite sprite;
    [SerializeField] private float speed;
    private World _world;
    private MovementSystem _movementSystem;
    private CameraFollowSystem _cameraFollowSystem;
    private HealthSystem _healthSystem;
    private Entity _playerEntity;
    void Start()
    {
        _world = World.Default;
        
        _movementSystem = new MovementSystem { World = _world };
        _cameraFollowSystem = new CameraFollowSystem { World = _world };
        _healthSystem = new HealthSystem() { World = _world };
        
        var systemsGroup = _world.CreateSystemsGroup();
        systemsGroup.AddSystem(_movementSystem);
        systemsGroup.AddSystem(_cameraFollowSystem);
        systemsGroup.AddSystem(_healthSystem);
        
        _world.AddPluginSystemsGroup(systemsGroup);
        _playerEntity = CreateEntityWithComponents();
        CreateCameraEntity();
    }

    private Entity CreateEntityWithComponents()
    {
        var entity = _world.CreateEntity();
        
        ref var position = ref entity.AddComponent<PositionComponent>();
        position.PositionValue = Vector2.zero;
        
        ref var velocity = ref entity.AddComponent<VelocityComponent>();
        velocity.VelocityValue = Vector2.zero;
        velocity.Speed = speed;
        
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

    void CreateCameraEntity()
    {
        var cameraEntity = _world.CreateEntity();
        ref var followTarget = ref cameraEntity.AddComponent<FollowTargetComponent>(out _);
        followTarget.TargetEntity = _playerEntity;
    }


}
