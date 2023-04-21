using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class PlayerInputManager : MonoBehaviour
    {
        private PlayerInputAction _PlayerInputAction;

        void Start()
        {
            _PlayerInputAction = new();
        }
        
        public void EnableGameplayInputs()
        {
            _PlayerInputAction.GamePlay.Enable();
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
