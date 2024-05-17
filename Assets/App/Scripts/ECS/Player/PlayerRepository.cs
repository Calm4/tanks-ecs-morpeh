using Scellecs.Morpeh.Providers;
using UnityEngine;

namespace App.Scripts.ECS.Player
{
    [CreateAssetMenu(fileName = "PlayerRepository", menuName = "Configs/Repositories/PlayerRepository", order = 0)]
    public class PlayerRepository : ScriptableObject
    {
        public EntityProvider prefab;
    }
}