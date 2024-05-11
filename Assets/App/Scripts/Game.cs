using System.Collections;
using System.Collections.Generic;
using App.Scripts.Components;
using Scellecs.Morpeh;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;
    private World world;
    private MovementSystem movementSystem;

    void Start()
    {
        this.world = World.Default;
        movementSystem = new MovementSystem { World = this.world };
        var systemsGroup = world.CreateSystemsGroup();
        systemsGroup.AddSystem(this.movementSystem);
        world.AddPluginSystemsGroup(systemsGroup);
        CreateEntityWithComponents();
    }

    void CreateEntityWithComponents()
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
    }
}