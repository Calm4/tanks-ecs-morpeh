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
        public sealed class AutoCannonSystem : SimpleFixedUpdateSystem<AutoCannonComponent>
        {
            protected override void Process(Entity entity, ref AutoCannonComponent cannon, in float deltaTime)
            {
                if (!cannon.canShoot)
                {
                    return;
                }

                if (Time.time - cannon.lastShotTime < cannon.config.reloadTime)
                {
                    return;
                }

                CreateBullet(entity, cannon);
                cannon.lastShotTime = Time.time;
            }

            private void CreateBullet(Entity entity, AutoCannonComponent cannon)
            {
                Rigidbody2D bulletBody = Instantiate(cannon.config.bulletConfig.prefab,
                    cannon.body.position,
                    Quaternion.identity);

                IgnoreSelfCollisions(bulletBody.GetComponent<Collider2D>(), entity);
                bulletBody.gameObject.SetActive(true);
                bulletBody.rotation = cannon.body.rotation;
                bulletBody.velocity = Quaternion.Euler(0f, 0f, bulletBody.rotation)
                                      * Vector3.up
                                      * cannon.config.speed;

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