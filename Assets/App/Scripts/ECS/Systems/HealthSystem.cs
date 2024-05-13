using App.Scripts.Components;
using UnityEngine;

namespace App.Scripts.Systems
{
    using Scellecs.Morpeh;

    public sealed class HealthSystem : ISystem
    {
        public World World { get; set; }
        private Filter _filter;

        public void OnAwake()
        {
            _filter = World.Filter.With<HealthComponent>().With<DamageComponent>().Build();

        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var healthComponent = ref entity.GetComponent<HealthComponent>();
                ref var damageComponent = ref entity.GetComponent<DamageComponent>();
                ref var gameObjectComponent = ref entity.GetComponent<GameObjectComponent>();

                if (Input.GetKeyDown(KeyCode.F))
                {
                    healthComponent.currentHealth -= damageComponent.Damage;
                    Debug.Log($"CurrentHealth/MaxHealth:  {healthComponent.currentHealth}/{healthComponent.maxHealth}");
                }

                if (healthComponent.currentHealth <= 0)
                {
                    Debug.Log("Died");
                    GameObject.Destroy(gameObjectComponent.GameObject);
                    entity.Dispose();
                }
            }
        }

        public void Dispose()
        {
        }
    }
}