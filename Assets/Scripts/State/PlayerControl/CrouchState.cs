using System;
using UnityEngine;

namespace State.PlayerControl
{
    [Serializable]
    [CreateAssetMenu(fileName = "CrouchState", menuName = "ScriptableObject/PlayerControl/State/Crouch")]
    class CrouchState : State
    {
        [Header("Config")]
        [SerializeField] private float _MaxSpeed;
        [SerializeField] private float _AccelerateTime;
        [SerializeField] private float _DecelerateTime;

        [Header("Information")]
        [SerializeField, ReadOnly] private float _MoveSpeed;
        [SerializeField, ReadOnly] private float _AccelerateSpeed;
        [SerializeField, ReadOnly] private float _DecelerateSpeed;

        public override void Initialize(StateMachine father)
        {
            base.Initialize(father);
            _AccelerateSpeed = _MaxSpeed / _AccelerateTime;
            _DecelerateSpeed = _MaxSpeed / _DecelerateTime;
        }
        public override void Enter()
        {
            base.Enter();
            _Paramaters.Player.IsCrouch = true;
            _MoveSpeed = Mathf.Clamp(_Paramaters.Velocity.x, -_MaxSpeed, _MaxSpeed);
        }
        public override void PopEnter()
        {
            base.PopEnter();
            _Paramaters.Player.IsCrouch = true;
            _MoveSpeed = Mathf.Clamp(_Paramaters.Velocity.x, -_MaxSpeed, _MaxSpeed);
        }
        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            if (_Paramaters.MoveX == 0)
            {
                _MoveSpeed = Mathf.MoveTowards(_MoveSpeed, 0, Time.deltaTime * _DecelerateSpeed);
            }
            else
            {
                _MoveSpeed += _Paramaters.MoveX * _AccelerateSpeed * Time.deltaTime;
                _MoveSpeed = Mathf.Clamp(_MoveSpeed, -_MaxSpeed, _MaxSpeed);
            }
            _Paramaters.Velocity.x = _MoveSpeed;
        }
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if(_Paramaters.IsTopBlocked)
            {
                return;
            }
            else if (_Paramaters.MoveY>=0 && _Paramaters.IsGround)
            {
                _FatherStateMachine.SwitchState(typeof(MoveState));
            }
            else if (_Paramaters.JumpBuffer > 0)
            {
                _FatherStateMachine.SwitchState(typeof(JumpState));
            }
            else if (_Paramaters.Velocity.y <= 0 && !_Paramaters.IsGround)
            {
                _FatherStateMachine.SwitchState(typeof(FallState));
            }
            else if (_Paramaters.IsDash)
            {
                _FatherStateMachine.SwitchState(typeof(DashState));
            }
            else if (_Paramaters.IsWall && _Paramaters.IsHeld)
            {
                _FatherStateMachine.SwitchState(typeof(ClimbWallState));
            }
        }
        public override void Exit()
        {
            base.Exit();
            _Paramaters.Player.IsCrouch = false;
        }
    }
}
