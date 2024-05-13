using Scellecs.Morpeh;
using UnityEngine;

namespace App.Scripts
{
    public class Game : MonoBehaviour
    { 
        [SerializeField] private Sprite sprite;
        [SerializeField] private float speed;
        [SerializeField] private float movementNormalization;
        private World _world;
        private EntityFactory _entityFactory;
        private void Start()
        {
            _world = World.Default;
            _entityFactory = new EntityFactory(_world);

            var playerEntity = _entityFactory.CreateEntityWithComponents(sprite,speed, movementNormalization);
            _entityFactory.CreateCameraEntity(playerEntity);
        }

     


    }
}
