using App.Scripts.Components;
using UnityEngine;

namespace App.Scripts
{
    using Scellecs.Morpeh;

    public class CameraFollowSystem : ISystem 
    {
        public World World { get; set; }
        private Filter filter;

        public void OnAwake() {
            this.filter = this.World.Filter.With<FollowTargetComponent>().Build();
        }

        public void OnUpdate(float deltaTime) {
            foreach (var entity in this.filter) {
                ref var followTarget = ref entity.GetComponent<FollowTargetComponent>();
                ref var position = ref followTarget.TargetEntity.GetComponent<PositionComponent>();

                // Обновляем позицию камеры
                Camera.main.transform.position = new Vector3(position.PositionValue.x, position.PositionValue.y, Camera.main.transform.position.z);
            }
        }

        public void Dispose() {
        }
    }

}