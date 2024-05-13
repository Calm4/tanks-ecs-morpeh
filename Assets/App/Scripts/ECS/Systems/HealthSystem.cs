using App.Scripts.Components;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace App.Scripts.ECS.Systems
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(HealthSystem), fileName = "Health System")]
    public sealed class HealthSystem : UpdateSystem
    {
        private Filter _filter;

        public override void OnAwake()
        {
            _filter = World.Filter.With<HealthComponent>().With<DamageComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
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

        public override void Dispose()
        {
        }
    }
}