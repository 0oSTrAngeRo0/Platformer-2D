using System;
using UnityEngine;

namespace State.PlayerControl
{
    [Serializable]
    [CreateAssetMenu(fileName = "FallState", menuName = "ScriptableObject/PlayerControl/State/Fall")]
    class FallState : State
    {
        [Header("Config")]
        [SerializeField] private float _Gravity;
        [SerializeField] private float _MaxFallSpeed;
        [SerializeField] private float _MaxSpeed;
        [SerializeField] private float _AccelerateTime;
        [SerializeField] private float _DecelerateTime;

        [Header("State Information")]
        [SerializeField, ReadOnly] private float _FallSpeed;
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
            _MoveSpeed = Mathf.Clamp(_Paramaters.Velocity.x, -_MaxSpeed, _MaxSpeed);
        }
        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            //Fall
            _Paramaters.Velocity.y = Mathf.Clamp(_Paramaters.Velocity.y - _Gravity * Time.deltaTime, _MaxFallSpeed, float.PositiveInfinity);

            //Move
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
            if (_Paramaters.IsGround)
            {
                _FatherStateMachine.SwitchState(typeof(LandState));
            }
            else if (_Paramaters.JumpBuffer > 0)
            {
                _FatherStateMachine.SwitchState(typeof(AirJumpState));
            }
            else if (_Paramaters.IsDash)
            {
                _FatherStateMachine.SwitchState(typeof(DashState));
            }
            else if (_Paramaters.IsWall && _Paramaters.IsHeld)
            {
                _FatherStateMachine.SwitchState(typeof(ClimbWallState));
            }
            else if (_Paramaters.IsGrab)
            {
                _FatherStateMachine.SwitchState(typeof(GrabDashState));
            }
        }
    }
}
