﻿using System;
using Scellecs.Morpeh;

namespace App.Scripts.ECS.Components
{
    [Serializable]
    public struct FollowTargetComponent : IComponent
    {
        public Entity TargetEntity;
    }
}