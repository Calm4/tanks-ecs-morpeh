using System;
using App.Scripts.ECS.Components;
using Scellecs.Morpeh;
using UnityEngine;

namespace App.Scripts
{
    public class CollisionDetector : MonoBehaviour
    {
        public Collider2D[] colliders;
        public Entity listener;
        private World world;
        
        public void Init(World world) {
            this.world = world;
        }

        private void OnEnable()
        {
            colliders = GetComponentsInChildren<Collider2D>();
            
            if (colliders.Length <= 0) {
                throw new Exception($"There are no any Colliders to handle collisions on {name}");
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (listener == null || !listener.Has<CanCollideComponent>()) {
                throw new Exception($"{nameof(listener)} should have {nameof(CanCollideComponent)}");
            }
            
            Entity eventEntity = world.CreateEntity();
            ref CollisionEventComponent evt = ref eventEntity.AddComponent<CollisionEventComponent>();
            evt.collision = other;
            evt.first = listener;

            var otherDetector = other.gameObject.GetComponent<CollisionDetector>();
            evt.second = otherDetector != null ? otherDetector.listener : null;
        }
    }
}