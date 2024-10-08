﻿using UnityEngine;

namespace App.Scripts.ECS.Weapons
{
    [CreateAssetMenu(fileName = "BulletWeaponConfig", menuName = "Configs/BulletWeaponConfig", order = 0)]
    public class BulletWeaponConfig : ScriptableObject
    {
        public BulletConfig bulletConfig;
        public float bulletSpeed;
        public float reloadTime;
    }
}