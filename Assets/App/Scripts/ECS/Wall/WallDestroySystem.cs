using App.Scripts.ECS.Health;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace App.Scripts.ECS.Wall
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(WallDestroySystem), fileName = "Wall Destroy System")]
    public sealed class WallDestroySystem : UpdateSystem
    {
        private Filter destroyedWalls;
        public override void OnAwake()
        {
            destroyedWalls = World.Filter.With<WallComponent>().With<IsDeadMarker>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (Entity ent in destroyedWalls) {
                GameObject wallGo = ent.GetComponent<WallComponent>().transform.gameObject;
                World.RemoveEntity(ent);
                Destroy(wallGo);
            }
        }
        public static WallDestroySystem Create() {
            return CreateInstance<WallDestroySystem>();
        }
    }
}