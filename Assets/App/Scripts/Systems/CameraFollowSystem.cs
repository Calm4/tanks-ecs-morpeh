using App.Scripts.Components;
using Scellecs.Morpeh;
using UnityEngine;

namespace App.Scripts.Systems
{
    public class CameraFollowSystem : ISystem {
        public World World { get; set; }
        private Filter _filter;

        public void OnAwake()
        {
            _filter = World.Filter.With<FollowTargetComponent>().Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var followTarget = ref entity.GetComponent<FollowTargetComponent>();
                ref var gameObject = ref followTarget.TargetEntity.GetComponent<GameObjectComponent>();
                Camera.main.transform.position = new Vector3(gameObject.GameObject.transform.position.x, gameObject.GameObject.transform.position.y, Camera.main.transform.position.z);
            }
        }


        public void Dispose()
        {
        }
    }
}