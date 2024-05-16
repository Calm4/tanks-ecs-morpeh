using App.Scripts.ECS.Components;
using Scellecs.Morpeh.Helpers;
using UnityEngine;
using Scellecs.Morpeh;

namespace App.Scripts.ECS.Systems
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(CollisionCleanSystem))]
    public sealed class CollisionCleanSystem : SimpleLateUpdateSystem<CollisionEventComponent>
    {
        protected override void Process(Entity ent, ref CollisionEventComponent evt, in float dt)
        {
            Debug.Log("[CollisionCleanSystem] Removing CollisionEventComponent entity");
            World.RemoveEntity(ent);
        }

        public static CollisionCleanSystem Create()
        {
            return CreateInstance<CollisionCleanSystem>();
        }
    }
}