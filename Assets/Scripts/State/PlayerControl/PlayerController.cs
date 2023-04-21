using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace State.PlayerControl
{
    public class PlayerController : MonoBehaviour
    {
        [field: SerializeField] public StateMachine _StateMachine { get; private set; }
        [field: SerializeField] public Paramaters _Paramaters { get; private set; }

        private Rigidbody2D _Rigidbody;

        [SerializeField, ReadOnly] private bool isCrouch;
        public bool IsCrouch
        {
            get { return isCrouch; }
            set
            {
                if (isCrouch != value)
                {
                    isCrouch = value;
                    transform.localScale = new(1, value?1:2, 1);
                    transform.position = new(transform.position.x, transform.position.y + (value?-0.5f:0.5f), transform.position.z);
                }
            }
        }

        [SerializeField, ReadOnly] private bool isDash;
        public bool IsDash
        {
            get { return isDash; }
            set
            {
                if (isDash != value)
                {
                    isDash = value;
                    transform.localScale = new(1, value ? 1 : 2, 1);
                    transform.position = new(transform.position.x, transform.position.y + (value ? 0.5f : -0.5f), transform.position.z);
                }
            }
        }

        private void Start()
        {
            _Paramaters.Player = GetComponent<PlayerController>();
            _Rigidbody = GetComponent<Rigidbody2D>();
            _Paramaters.Initialize();
            _StateMachine.Initialize();
        }

        private void Update()
        {
            _Paramaters.LogicUpdate();
            _StateMachine.LogicUpdate();
        }

        private void FixedUpdate()
        {
            _Paramaters.PlayerPosition = transform.position;
            _Paramaters.PhysicsUpdate();
            _StateMachine.PhysicsUpdate();
            _Rigidbody.velocity = _Paramaters.Velocity;
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            if(context.performed)
            {
                //Debug.Log(context.ReadValue<float>());
                _Paramaters.MoveX = context.ReadValue<float>();
            }
            else if(context.canceled)
            {
                _Paramaters.MoveX = 0;
            }
        }
        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                //Debug.Log(context.ReadValue<float>());
                _Paramaters.JumpBuffer = _Paramaters.JumpBufferTime;

            }
            else if (context.canceled)
            {
                //_Paramaters.Move = 0;
            }
        }
        public void OnCrouch(InputAction.CallbackContext context)
        {
            if(context.performed)
            {
                _Paramaters.MoveY = context.ReadValue<float>();
            }
            else if(context.canceled)
            {
                _Paramaters.MoveY = 0;
            }
        }
        public void OnDash(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _Paramaters.IsDash = true;
            }
            else if (context.canceled)
            {
                _Paramaters.IsDash = false;
            }
        }
        public void OnHeld(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _Paramaters.IsHeld = true;
            }
            else if (context.canceled)
            {
                _Paramaters.IsHeld = false;
            }
        }
    }
}
