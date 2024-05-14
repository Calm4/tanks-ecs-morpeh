using UnityEngine;

namespace App.Scripts
{
    [CreateAssetMenu(fileName = "BulletConfig", menuName = "Configs/BulletConfig", order = 0)]
    public class BulletConfig : ScriptableObject
    {
        public Rigidbody2D prefab;
        public float damage;
    }
}