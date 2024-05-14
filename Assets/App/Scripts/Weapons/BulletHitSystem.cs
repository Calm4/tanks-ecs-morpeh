using App.Scripts.ECS.Components;
using Scellecs.Morpeh.Helpers;
using UnityEngine;
using Scellecs.Morpeh;

namespace App.Scripts.Weapons
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(BulletHitSystem), fileName = "Bullet Hit System")]
    public sealed class BulletHitSystem : SimpleFixedUpdateSystem<CollisionEventComponent>
    {
        protected override void Process(Entity entity, ref CollisionEventComponent eventComponent, in float deltaTime)
        {
            Entity bulletEntity = eventComponent.first;
            ref BulletComponent bullet = ref bulletEntity.GetComponent<BulletComponent>(out bool isBullet);

            if (!isBullet)
            {
                return;
            }

            if (eventComponent.second != null)
            {
                eventComponent.second.SetComponent(new DamageEventComponent()
                {
                    hitPosition = eventComponent.collision.GetContact(0).point,
                    amount = bullet.config.damage,
                    dealer = bullet.shooter
                });
            }
        }

        public static BulletHitSystem Create()
        {
            return CreateInstance<BulletHitSystem>();
        }
    }
}