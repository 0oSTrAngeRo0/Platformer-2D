using System;
using UnityEngine;

namespace State.PlayerControl
{
    [Serializable]
    [CreateAssetMenu(fileName = "JumpState", menuName = "ScriptableObject/PlayerControl/State/Jump")]
    public class JumpState : State
    {
        [Header("Config")]
        [SerializeField] private float _Height;
        [SerializeField] private float _Gravity;
        [SerializeField] private float _MaxSpeed;
        [SerializeField] private float _AccelerateTime;
        [SerializeField] private float _DecelerateTime;

        [Header("Information")]
        [SerializeField, ReadOnly] private float _JumpSpeed;
        [SerializeField, ReadOnly] private float _MoveSpeed;
        [SerializeField, ReadOnly] private float _AccelerateSpeed;
        [SerializeField, ReadOnly] private float _DecelerateSpeed;

        public override void Initialize(StateMachine father)
        {
            base.Initialize(father);
            _JumpSpeed = Mathf.Sqrt(2 * _Gravity * _Height);
            _AccelerateSpeed = _MaxSpeed / _AccelerateTime;
            _DecelerateSpeed = _MaxSpeed / _DecelerateTime;
        }
        public override void Enter()
        {
            _Paramaters.JumpBuffer = -1;
            //_JumpSpeed = Mathf.Sqrt(2 * _Gravity * _Height); //可注释，用于调试最合适的重力
            _Paramaters.Velocity.y = _JumpSpeed;
            _MoveSpeed = Mathf.Clamp(_Paramaters.Velocity.x, -_MaxSpeed, _MaxSpeed);

        }
        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            //Fall
            _Paramaters.Velocity.y -= _Gravity * Time.deltaTime;

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
            if (_Paramaters.Velocity.y < 0)
            {
                _FatherStateMachine.SwitchState(typeof(FallState));
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
        }
    }
}
