using App.Scripts.ECS.Components;
using Scellecs.Morpeh.Helpers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace App.Scripts.ECS.Systems
{
    using Scellecs.Morpeh;

    public sealed class UserMovementSystem : SimpleUpdateSystem<MoveDirectionComponent, ControlledByUserComponent>
    {
        protected override void Process(Entity entity, ref MoveDirectionComponent moveDirection, ref ControlledByUserComponent controlledByUser, in float deltaTime)
        {
            PlayerInputActions inputActions = controlledByUser.user.GetComponent<GameUser>().inputActions;
            moveDirection.direction = inputActions.Player.Movement.ReadValue<Vector2>();
        }
    }
}