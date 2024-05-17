using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace App.Scripts.ECS.Health
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(DamageCleanSystem), fileName = "Damage Clean System")]
    public sealed class DamageCleanSystem : LateUpdateSystem
    {
        private Filter _filter;
        public override void OnAwake()
        {
            _filter = World.Filter.With<DamageEventComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                Debug.Log("[DamageCleanSystem] Removing DamageEventComponent");
                entity.RemoveComponent<DamageEventComponent>();
            }
        }
        
        public static DamageCleanSystem Create() {
            return CreateInstance<DamageCleanSystem>();
        }
    }
}