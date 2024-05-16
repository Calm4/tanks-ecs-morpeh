using App.Scripts.ECS.Components;
using Scellecs.Morpeh.Helpers;
using UnityEngine;
using Scellecs.Morpeh;

namespace App.Scripts.Weapons
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(BulletHitSystem), fileName = "Bullet Hit System")]
    public sealed class BulletHitSystem : SimpleFixedUpdateSystem<CollisionEventComponent> {
        protected override void Process(Entity ent, ref CollisionEventComponent evt, in float dt) {
            Entity bulletEntity = evt.first;
            ref BulletComponent bullet = ref bulletEntity.GetComponent<BulletComponent>(out bool isBullet);
            if (!isBullet) {
                return;
            }

            if (evt.second != null ) {
                evt.second.SetComponent(new DamageEventComponent() {
                    hitPosition = evt.collision?.GetContact(0).point,
                    amount = bullet.config.damage,
                    dealer = bullet.shooter,
                });
            }

            Destroy(bullet.body.gameObject);
            bulletEntity.RemoveComponent<BulletComponent>();
            World.RemoveEntity(bulletEntity);
        }

        public static BulletHitSystem Create() {
            return CreateInstance<BulletHitSystem>();
        }
    }
}