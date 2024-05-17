using App.Scripts.ECS.Cannon;
using App.Scripts.ECS.Collision;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Helpers;
using UnityEngine;

namespace App.Scripts.ECS.Weapons
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(BulletGeneratorSystem))]
    public class BulletGeneratorSystem : SimpleFixedUpdateSystem<BulletWeaponComponent, CannonComponent>
    {
        protected override void Process(Entity entity, ref BulletWeaponComponent weapon, ref CannonComponent cannon, in float deltaTime)
        {
            if (!weapon.shoot) {
                return;
            }

            if (Time.time - weapon.lastShotTime < weapon.config.reloadTime)
            {
                return;
            }
            
            CreateBullet(entity, weapon, cannon);
            weapon.lastShotTime = Time.time;
        }

        private void CreateBullet(Entity entity, BulletWeaponComponent weapon, CannonComponent cannon)
        {
            Rigidbody2D bulletBody = Instantiate(weapon.config.bulletConfig.prefab,
                cannon.body.position,
                Quaternion.identity);

            IgnoreSelfCollisions(bulletBody.GetComponent<Collider2D>(), entity);
            bulletBody.gameObject.SetActive(true);
            bulletBody.rotation = cannon.body.rotation;
            bulletBody.velocity = Quaternion.Euler(0f, 0f, bulletBody.rotation)
                                  * Vector3.up
                                  * weapon.config.bulletSpeed;

            World.CreateEntity().SetComponent(new BulletComponent() {
                body = bulletBody,
                config = weapon.config.bulletConfig,
                shooter = entity,
            });
        }
        private void IgnoreSelfCollisions(Collider2D bulletCollider, Entity entity)
        {
            ref CanCollideComponent canCollide = ref entity.GetComponent<CanCollideComponent>(out bool hasCanCollide);
            if (bulletCollider == null || !hasCanCollide)
            {
                return;
            }

            foreach (Collider2D selfCollider in canCollide.detector.colliders)
            {
                Physics2D.IgnoreCollision(selfCollider, bulletCollider);
            }
        }
    }
}