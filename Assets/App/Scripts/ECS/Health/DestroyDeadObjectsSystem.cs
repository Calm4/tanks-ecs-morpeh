using App.Scripts.ECS.Cannon;
using App.Scripts.ECS.Player;
using App.Scripts.ECS.Wall;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace App.Scripts.ECS.Health
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(DestroyDeadObjectsSystem), fileName = "Destroy Dead Objects System")]
    public sealed class DestroyDeadObjectsSystem : UpdateSystem
    {
        private Filter _wallsFilter;
        private Filter _playersFilter;
        private Filter _cannonsFilter;
        
        public override void OnAwake()
        {
            _wallsFilter = World.Filter.With<WallComponent>().With<IsDeadMarker>().Build();
            _playersFilter = World.Filter.With<PlayerComponent>().With<IsDeadMarker>().Build();
            _cannonsFilter = World.Filter.With<AutoCannonComponent>().With<IsDeadMarker>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _wallsFilter)
            {
                GameObject wallGo = entity.GetComponent<WallComponent>().transform.gameObject;
                World.RemoveEntity(entity);
                Destroy(wallGo);
            }

            foreach (var entity in _playersFilter)
            {
                GameObject playerGo = entity.GetComponent<PlayerComponent>().body.gameObject;
                World.RemoveEntity(entity);
                Destroy(playerGo);
            }

            foreach (var entity in _cannonsFilter)
            {
                GameObject cannonGo = entity.GetComponent<AutoCannonComponent>().body.gameObject;
                World.RemoveEntity(entity);
                Destroy(cannonGo);
            }
        }
    }
}