using App.Scripts.ECS.Player;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Helpers;
using UnityEngine;

namespace App.Scripts.ECS.Movement
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(MovementSystem), fileName = "Movement System")]
    public sealed class MovementSystem : SimpleFixedUpdateSystem<PlayerComponent ,MoveDirectionComponent>
    {
        protected override void Process(Entity entity, ref PlayerComponent player, ref MoveDirectionComponent moveDirection, in float deltaTime)
        {
            Vector2 direction = moveDirection.direction;
            Vector2 velocity = player.config.speed * direction;

            player.body.velocity = velocity;
            player.body.angularVelocity = 0f;
            
            if (direction.sqrMagnitude <= 0f)
            {
                return;
            }

            float angle = Vector2.SignedAngle(Vector2.up, direction);
            player.body.rotation = angle;
        }
        
        public static MovementSystem Create() {
            return CreateInstance<MovementSystem>();
        }
    }
}