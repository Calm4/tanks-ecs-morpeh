using Scellecs.Morpeh;
using Scellecs.Morpeh.Helpers;
using UnityEngine;

namespace App.Scripts.ECS.Collision
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