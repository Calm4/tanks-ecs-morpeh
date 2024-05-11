using App.Scripts.Components;
using UnityEngine;
using Scellecs.Morpeh;

namespace App.Scripts
{
    public class CameraFollowSystem : ISystem
    {
        public World World { get; set; }
        private Filter filter;

        public void OnAwake()
        {
            this.filter = this.World.Filter.With<FollowTargetComponent>().Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in this.filter)
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