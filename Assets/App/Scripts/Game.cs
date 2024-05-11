using System.Collections;
using System.Collections.Generic;
using App.Scripts;
using App.Scripts.Components;
using Scellecs.Morpeh;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;
    private World world;
    private MovementSystem movementSystem;
    private CameraFollowSystem _cameraFollowSystem;
    private Entity playerEntity;
    void Start()
    {
        this.world = World.Default;
        movementSystem = new MovementSystem { World = this.world };
        _cameraFollowSystem = new CameraFollowSystem { World = this.world };
        var systemsGroup = world.CreateSystemsGroup();
        systemsGroup.AddSystem(this.movementSystem);
        systemsGroup.AddSystem(this._cameraFollowSystem);
        world.AddPluginSystemsGroup(systemsGroup);
        playerEntity = CreateEntityWithComponents();
        CreateCameraEntity();
    }

    private Entity CreateEntityWithComponents()
    {
        var entity = this.world.CreateEntity();

        ref var position = ref entity.AddComponent<PositionComponent>();
        position.PositionValue = new Vector2(4, 0);
        
        ref var velocity = ref entity.AddComponent<VelocityComponent>();
        velocity.Speed = 5f;

        ref var gameObjectComponent = ref entity.AddComponent<GameObjectComponent>();
        gameObjectComponent.GameObject = new GameObject("Entity");

        ref var spriteRendererComponent = ref entity.AddComponent<SpriteRendererComponent>();
        spriteRendererComponent.SpriteRenderer = gameObjectComponent.GameObject.AddComponent<SpriteRenderer>();
        spriteRendererComponent.SpriteRenderer.sprite = _sprite;
        return entity;
    }

    void CreateCameraEntity()
    {
        var cameraEntity = this.world.CreateEntity();
        
        ref var followTargetComponent = ref cameraEntity.AddComponent<FollowTargetComponent>();
        followTargetComponent.TargetEntity = playerEntity;
    }
}