using App.Scripts.ECS.Components;
using Scellecs.Morpeh.Systems;
using UnityEngine;
    using Scellecs.Morpeh;

namespace App.Scripts.ECS.Systems
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(DestroyEnemySystem), fileName = "Destroy Enemy System")]
    public sealed class DestroyEnemySystem : UpdateSystem
    {
        private Filter _destroyedEnemies;

        public override void OnAwake()
        {
            _destroyedEnemies = World.Filter.With<EnemyComponent>().With<IsDeadMarker>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _destroyedEnemies)
            {
                GameObject enemyGo = entity.GetComponent<EnemyComponent>().transform.gameObject;
                World.RemoveEntity(entity);
                Destroy(enemyGo);
            }
        }

        public override void Dispose()
        {
        }
    }
}