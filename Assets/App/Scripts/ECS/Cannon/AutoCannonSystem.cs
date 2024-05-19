using App.Scripts.ECS.Collision;
using App.Scripts.ECS.Weapons;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Helpers;
using UnityEngine;

namespace App.Scripts.ECS.Cannon
{
    namespace App.Scripts.ECS.Cannon
    {
        [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(AutoCannonSystem), fileName = "Auto Cannon System")]
        public sealed class AutoCannonSystem : SimpleFixedUpdateSystem<BulletWeaponComponent>
        {
            protected override void Process(Entity entity, ref BulletWeaponComponent cannon, in float deltaTime)
            {
                if (Time.time - cannon.lastShotTime < cannon.config.reloadTime)
                {
                    return;
                }

                CreateBullet(entity, cannon);
                cannon.lastShotTime = Time.time;
            }

            private void CreateBullet(Entity entity, BulletWeaponComponent cannon)
            {
                Rigidbody2D bulletBody = Instantiate(cannon.config.bulletConfig.prefab,
                    cannon.shootPoint.position,
                    Quaternion.identity);

                IgnoreSelfCollisions(bulletBody.GetComponent<Collider2D>(), entity);
                
                bulletBody.rotation = cannon.body.rotation;
                
                Vector2 cannonPosition = cannon.body.position;
                Vector2 shootDirectionPosition = cannon.shootPoint.position;
                Vector2 shootDirection = (shootDirectionPosition - cannonPosition).normalized;
                bulletBody.velocity = shootDirection * cannon.config.bulletSpeed;
                
                World.CreateEntity().SetComponent(new BulletComponent()
                {
                    body = bulletBody,
                    config = cannon.config.bulletConfig,
                    shooter = entity,
                });
            }

            private void IgnoreSelfCollisions(Collider2D bulletCollider, Entity entity)
            {
                ref CanCollideComponent canCollide =
                    ref entity.GetComponent<CanCollideComponent>(out bool hasCanCollide);
                if (bulletCollider == null || !hasCanCollide)
                {
                    return;
                }

                foreach (Collider2D selfCollider in canCollide.detector.colliders)
                {
                    Physics2D.IgnoreCollision(selfCollider, bulletCollider);
                }
            }

            public static AutoCannonSystem Create()
            {
                return CreateInstance<AutoCannonSystem>();
            }
        }
    }
}