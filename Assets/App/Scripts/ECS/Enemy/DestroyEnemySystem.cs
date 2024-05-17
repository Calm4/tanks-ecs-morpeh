using App.Scripts.ECS.Health;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace App.Scripts.ECS.Enemy
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