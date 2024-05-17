using System;
using Scellecs.Morpeh;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

namespace App.Scripts.ECS.GameInput {

    [Serializable]
    public struct GameUser : IComponent, IDisposable {
        public InputDevice device;
        public PlayerInputActions inputActions;
        public InputUser user;
        public int id;

        public void Dispose() {
            inputActions?.Disable();

            if (!user.valid) {
                return;
            }

            user.UnpairDevicesAndRemoveUser();
        }
    }
}