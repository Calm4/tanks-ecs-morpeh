using App.Scripts.Components;
using App.Scripts.ECS.Components;
using Scellecs.Morpeh;
using UnityEngine;

namespace App.Scripts.ECS.Systems
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(EnemyHealthSystem), fileName = "Enemy Health System")]
    public sealed class EnemyHealthSystem : ISystem
    {
        public World World { get; set; }
        private Filter _filter;
        private Filter _playerFilter;

        public void OnAwake()
        {
            _filter = World.Filter.With<EnemyComponent>().With<HealthComponent>().Build();
            _playerFilter = World.Filter.With<PlayerComponent>().Build();
        }

        int playerDamage = 0;

        public void OnUpdate(float deltaTime)
        {
            foreach (var playerEntity in _playerFilter)
            {
                ref var playerDamageComponent = ref playerEntity.GetComponent<DamageComponent>();
                playerDamage = playerDamageComponent.Damage;
            }

            /*foreach (var entity in _filter)
            {
                ref var health = ref entity.GetComponent<HealthComponent>();
                health.currentHealth -= playerDamage;
                Debug.Log("CurrentHealth:" + health.currentHealth);
                Debug.Log("Enemy hit!");
            }*/
        }

        public void Dispose()
        {
        }
    }
}