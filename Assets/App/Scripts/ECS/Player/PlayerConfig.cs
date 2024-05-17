using UnityEngine;

namespace App.Scripts.ECS.Player
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig", order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        public float speed;
    }
}