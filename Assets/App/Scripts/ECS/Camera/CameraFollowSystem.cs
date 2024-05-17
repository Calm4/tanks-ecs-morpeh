using App.Scripts.ECS.Player;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace App.Scripts.ECS.Camera
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(CameraFollowSystem), fileName = "Camera Follow System")]
    public sealed class CameraFollowSystem : UpdateSystem {
        private Filter _filter;

        public override void OnAwake()
        {
            _filter = World.Filter.With<PlayerComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var followTarget = ref entity.GetComponent<PlayerComponent>();
                UnityEngine.Camera.main.transform.position = new Vector3(followTarget.body.gameObject.transform.position.x, followTarget.body.gameObject.transform.position.y, UnityEngine.Camera.main.transform.position.z);
            }
        }


        public override void Dispose()
        {
        }
    }
}