using App.Scripts.Components;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace App.Scripts.Systems
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(MovementSystem), fileName = "Movement System")]
    public class MovementSystem : UpdateSystem {
        private Filter _filter;
        public override void OnAwake()
        {
            _filter = World.Filter.With<PositionComponent>().With<VelocityComponent>().With<GameObjectComponent>().With<SpriteRendererComponent>().Build();
        }

        public override void OnUpdate(float deltaTime) {
            foreach (var entity in _filter) {
                ref var position = ref entity.GetComponent<PositionComponent>();
                ref var velocity = ref entity.GetComponent<VelocityComponent>();
                ref var gameObject = ref entity.GetComponent<GameObjectComponent>();

                float horizontalInput = Input.GetAxisRaw("Horizontal");
                float verticalInput = Input.GetAxisRaw("Vertical");
            
                Vector2 input = new Vector2(horizontalInput, verticalInput);
            
                velocity.velocityValue = input.normalized * velocity.speed * velocity.movementNormalization;
                Vector2 newPosition = position.PositionValue + velocity.velocityValue;
            
                var rigidbody2D = gameObject.GameObject.GetComponent<Rigidbody2D>();
                rigidbody2D.MovePosition(newPosition);

                position.PositionValue = rigidbody2D.position;
            }
        }


        public override void Dispose() {
        }
    }
}

