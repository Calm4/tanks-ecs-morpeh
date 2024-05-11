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
            ref var gameObject = ref entity.GetComponent<GameObjectComponent>();

            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");
            
            Vector2 input = new Vector2(horizontalInput, verticalInput);
            
            velocity.VelocityValue = input.normalized * velocity.Speed;
            Vector2 newPosition = position.PositionValue + velocity.VelocityValue * deltaTime;
            
            var rigidbody2D = gameObject.GameObject.GetComponent<Rigidbody2D>();
            rigidbody2D.MovePosition(newPosition);

            position.PositionValue = rigidbody2D.position;
        }
    }


    public void Dispose() {
    }
}

