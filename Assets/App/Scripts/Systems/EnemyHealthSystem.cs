using App.Scripts.Components;
using UnityEngine;
using UnityEngine.UIElements;
using Scellecs.Morpeh;

namespace App.Scripts.Systems
{
    public sealed class EnemyHealthSystem : ISystem
    {
        public World World { get; set; }
        private Filter _filter;
        private Filter _playerfilter;

        public void OnAwake()
        {
            _filter = World.Filter.With<EnemyComponent>().With<HealthComponent>().Build();
            _playerfilter = World.Filter.With<PlayerComponent>().Build();
        }

        int playerDamage = 0;

        public void OnUpdate(float deltaTime)
        {
            foreach (var playerEntity in _playerfilter)
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