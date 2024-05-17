using Scellecs.Morpeh;
using Scellecs.Morpeh.Helpers;
using UnityEngine;

namespace App.Scripts.ECS.Weapons
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(BulletGeneratorSystem))]
    public class BulletGeneratorSystem : SimpleFixedSystem<BulletWeaponComponent, BulletGeneratorComponent>
    {
        protected override void Process(Entity entity, ref BulletWeaponComponent weapon, ref BulletGeneratorComponent bulletGenerator, in float deltaTime)
        {
            if (!weapon.shoot) {
                return;
            }

            if (Time.time - weapon.lastShotTime < weapon.config.reloadTime)
            {
                
            }
        }
    }
}