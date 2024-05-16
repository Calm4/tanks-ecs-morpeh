using App.Scripts.ECS.Components;
using Scellecs.Morpeh.Helpers;
using UnityEngine;
using Scellecs.Morpeh;

namespace App.Scripts.Weapons
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(BulletWeaponSystem), fileName = "Bullet Weapon System")]
    public sealed class BulletWeaponSystem : SimpleFixedUpdateSystem<BulletWeaponComponent, PlayerComponent>
    {
        protected override void Process(Entity entity, ref BulletWeaponComponent weapon, ref PlayerComponent player,
            in float deltaTime)
        {
            if (!weapon.shoot)
            {
                return;
            }

            if (Time.time - weapon.lastShotTime < weapon.config.reloadTime)
            {
                return;
            }

            CreateBullet(entity, weapon, player);
            weapon.lastShotTime = Time.time;
        }

        private void CreateBullet(Entity entity, BulletWeaponComponent weapon, PlayerComponent player)
        {
            Rigidbody2D bulletBody = Instantiate(weapon.config.bulletConfig.prefab,
                player.body.position,
                Quaternion.identity);

            IgnoreSelfCollisions(bulletBody.GetComponent<Collider2D>(), entity);
            bulletBody.gameObject.SetActive(true);
            bulletBody.rotation = player.body.rotation;
            bulletBody.velocity = Quaternion.Euler(0f, 0f, bulletBody.rotation)
                                  * Vector3.up
                                  * weapon.config.bulletSpeed;
            
            World.CreateEntity().SetComponent(new BulletComponent()
            {
                body = bulletBody,
                config = weapon.config.bulletConfig,
                shooter = entity
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

        public static BulletWeaponSystem Create()
        {
            return CreateInstance<BulletWeaponSystem>();
        }
    }
}