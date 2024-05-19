using App.Scripts.ECS.Weapons;
using UnityEngine;

namespace App.Scripts.ECS.Cannon
{
    [CreateAssetMenu(fileName = "CannonConfig", menuName = "Configs/CannonConfig", order = 0)]
    public class CannonConfig : ScriptableObject
    {
        public float speed;
        public float reloadTime;  
        public BulletConfig bulletConfig; 
    }
}