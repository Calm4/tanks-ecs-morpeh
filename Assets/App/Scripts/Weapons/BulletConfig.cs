using UnityEngine;

namespace App.Scripts.Weapons
{
    [CreateAssetMenu(fileName = "BulletConfig", menuName = "Configs/BulletConfig", order = 0)]
    public class BulletConfig : ScriptableObject
    {
        public Rigidbody2D prefab;
        public int damage;
    }
}