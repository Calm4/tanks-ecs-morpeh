using App.Scripts.Components;
using App.Scripts.ECS.Components;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace App.Scripts.ECS.Systems
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(HealthSystem), fileName = "Health System")]
    public sealed class HealthSystem : UpdateSystem
    {
        private Filter _playerFilter;
        private Filter _wallsFilter;

        public override void OnAwake()
        {
            _playerFilter = World.Filter.With<PlayerComponent>().With<HealthComponent>().Build();
            _wallsFilter = World.Filter.With<WallComponent>().Build();
            
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _playerFilter)
            {
                ref var playerComponent = ref entity.GetComponent<PlayerComponent>();
                ref var healthComponent = ref entity.GetComponent<HealthComponent>();

                if (Input.GetKeyDown(KeyCode.F))
                {
                    Debug.Log($"CurrentHealth/MaxHealth:  {healthComponent.currentHealth}/{healthComponent.maxHealth}");
                }

                if (healthComponent.currentHealth <= 0)
                {
                    Debug.Log("Died");
                    Destroy(playerComponent.body.gameObject);
                    entity.Dispose();
                }
            }
            foreach (var entity in _wallsFilter)
            {
                ref var healthComponent = ref entity.GetComponent<HealthComponent>();
            }
        }

        public override void Dispose()
        {
        }
    }
}