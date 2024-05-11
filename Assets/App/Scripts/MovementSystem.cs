using System.Collections;
using System.Collections.Generic;
using App.Scripts.Components;
using Scellecs.Morpeh;
using UnityEngine;

public class MovementSystem : ISystem 
{
    public World World { get; set; }
    private Filter filter;

    public void OnAwake() {
        filter = World.Filter.With<PositionComponent>().With<VelocityComponent>().With<GameObjectComponent>().With<SpriteRendererComponent>().Build();
    }

    public void OnUpdate(float deltaTime) {
        foreach (var entity in filter) {
            ref var position = ref entity.GetComponent<PositionComponent>();
            ref var velocity = ref entity.GetComponent<VelocityComponent>();
            ref var gameObjectComponent = ref entity.GetComponent<GameObjectComponent>();

            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            velocity.VelocityValue = new Vector2(horizontalInput, verticalInput).normalized;

            position.PositionValue += velocity.VelocityValue * deltaTime * velocity.Speed;
            gameObjectComponent.GameObject.transform.position = position.PositionValue;
        }
    }


    public void Dispose() {
    }
}
