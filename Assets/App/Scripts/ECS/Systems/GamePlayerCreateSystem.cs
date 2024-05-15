using App.Scripts.ECS.Components;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using UnityEngine.Serialization;

namespace App.Scripts.ECS.Systems
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(GamePlayerCreateSystem), fileName = "Game Player Create System")]
    public sealed class GamePlayerCreateSystem : UpdateSystem
    {
        public PlayerRepository playerRepository;
        private Filter _filter;
        public override void OnAwake()
        {
            _filter = World.Filter.With<GameUser>().Without<UserWithPlayer>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                SpawnPlayer(entity, out Entity playerEntity, out Transform playerTransform);
            }
           
        }

        private void SpawnPlayer(Entity userEntity, out Entity playerEntity, out Transform playerTransform)
        {
            EntityProvider playerPrefab = playerRepository.prefab;
            EntityProvider playerInstance = Instantiate(playerPrefab);

            playerEntity = playerInstance.Entity;
            playerTransform = playerInstance.transform;

            userEntity.AddComponent<UserWithPlayer>().player = playerEntity;
            userEntity.AddComponent<ControlledByUserComponent>().user = userEntity;

        }
    }
}