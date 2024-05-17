using App.Scripts.ECS.Components;
using Scellecs.Morpeh.Helpers;
using UnityEngine.InputSystem;
    using Scellecs.Morpeh;
    using UnityEngine;

    namespace App.Scripts.Weapons
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(UserBulletWeaponSystem), fileName = "User Bullet Weapon System")]
    public sealed class UserBulletWeaponSystem : SimpleUpdateSystem<BulletWeaponComponent, ControlledByUserComponent>
    {
        protected override void Process(Entity entinty,
            ref BulletWeaponComponent weapon,
            ref ControlledByUserComponent controlledByUserComponent,
            in float deltaTime)
        {
            InputActionPhase actionPhase =
                controlledByUserComponent.user.GetComponent<GameUser>().inputActions.Player.Fire.phase;
            weapon.shoot = actionPhase == InputActionPhase.Started || actionPhase == InputActionPhase.Performed;
        }

        public static UserBulletWeaponSystem Create()
        {
            return CreateInstance<UserBulletWeaponSystem>();
        }
    }
}