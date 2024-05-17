using App.Scripts.ECS.GameInput;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Helpers;
using UnityEngine;

namespace App.Scripts.ECS.Movement
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(UserMovementSystem), fileName = "User Movement System")]
    public sealed class UserMovementSystem : SimpleUpdateSystem<MoveDirectionComponent, ControlledByUserComponent>
    {
        protected override void Process(Entity entity, ref MoveDirectionComponent moveDirection, ref ControlledByUserComponent controlledByUser, in float deltaTime)
        {
            PlayerInputActions inputActions = controlledByUser.user.GetComponent<GameUser>().inputActions;
            moveDirection.direction = inputActions.Player.Movement.ReadValue<Vector2>();
        }
    }
}