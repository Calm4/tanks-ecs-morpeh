using App.Scripts.ECS.Components;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using UnityEngine.EventSystems;
using Scellecs.Morpeh;

namespace App.Scripts.ECS.Systems
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(PlayerMovementInitSystem), fileName = "Player Movement Init System")]
    public sealed class PlayerMovementInitSystem : UpdateSystem
    {
        private Filter _filter;

        public override void OnAwake()
        {
            _filter = World.Filter.With<PlayerComponent>().Without<MoveDirectionComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                entity.AddComponent<MoveDirectionComponent>();
            }
        }

        public static PlayerMovementInitSystem Create()
        {
            return CreateInstance<PlayerMovementInitSystem>();
        }
    }
}