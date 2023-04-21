using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class PlayerInputManager : MonoBehaviour
    {
        private PlayerInputActions _PlayerInputActions;

        void Start()
        {
            _PlayerInputActions = new();
        }
        
        public void EnableGameplayInputs()
        {
            _PlayerInputActions.GamePlay.Enable();
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
