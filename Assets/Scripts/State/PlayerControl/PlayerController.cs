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
        [field: SerializeField] public List<Collider2D> _Colliders { get; private set; }
        [field: SerializeField] public List<GameObject> _Characters { get; private set; }

        private Rigidbody2D _Rigidbody;
        private Transform _Character;

        [SerializeField, ReadOnly] private bool isCrouch;
        public bool IsCrouch
        {
            get { return isCrouch; }
            set
            {
                if (isCrouch != value)
                {
                    isCrouch = value;
                    SwitchCharacter(value ? 1 : 0);
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
                    SwitchCharacter(value ? 2 : 0);
                }
            }
        }

        private void Start()
        {
            _Paramaters.Player = GetComponent<PlayerController>();
            _Rigidbody = GetComponent<Rigidbody2D>();
            _Paramaters.Initialize();
            _StateMachine.Initialize();
            _Colliders ??= new List<Collider2D>();
            _Characters ??= new List<GameObject>();
            _Character ??= transform.Find("Charactor");
            SwitchCharacter(0);
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

        private void SwitchCharacter(int index)
        {
            for (int i = 0; i < _Character.childCount; i++)
            {
                _Character.GetChild(i).gameObject.SetActive(false);
            }

            Transform active = _Character.GetChild(index);
            active.gameObject.SetActive(true);
            foreach (Collider2D collider2D in _Colliders)
            {
                Transform colliderTransform = collider2D.transform;
                colliderTransform.position = active.position;
                colliderTransform.rotation = active.rotation;
                colliderTransform.localScale = active.localScale;
            }
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
