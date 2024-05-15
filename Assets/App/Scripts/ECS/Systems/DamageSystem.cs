using App.Scripts.ECS.Components;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Helpers;
using UnityEngine;

namespace App.Scripts.ECS.Systems
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(DamageSystem), fileName = "Damage System")]
    public sealed class DamageSystem : SimpleUpdateSystem<HealthComponent, DamageEventComponent>
    {
        protected override void Process(Entity entity, ref HealthComponent health, ref DamageEventComponent damage, in float deltaTime)
        {
            if (damage.amount <= 0)
            {
                return;
            }

            health.currentHealth -= damage.amount;
            if (health.currentHealth > 0)
            {
                return;
            }
            
            entity.SetComponent(new IsDeadMarker());
            
        }

        public static DamageSystem Create()
        {
            return CreateInstance<DamageSystem>();
        }
    }
}