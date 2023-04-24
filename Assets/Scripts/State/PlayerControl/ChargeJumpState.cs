using System;
using UnityEngine;

namespace State.PlayerControl
{
    [Serializable]
    [CreateAssetMenu(fileName = "ChargeJumpState", menuName = "ScriptableObject/PlayerControl/State/ChargeJumpState")]
    public class ChargeJumpState : State
    {
        [Header("Config")] 
        [SerializeField] private float _MaxJumpHeight;
        [SerializeField] private float _Gravity;
        [SerializeField] private float _MaxSpeed;
        [SerializeField] private float _AccelerateTime;
        [SerializeField] private float _DecelerateTime;
        [SerializeField] private AnimationCurve _JumpHeightMap;

        [Header("Information")]
        [SerializeField, ReadOnly] private float _JumpSpeed;
        [SerializeField, ReadOnly] private float _MoveSpeed;
        [SerializeField, ReadOnly] private float _AccelerateSpeed;
        [SerializeField, ReadOnly] private float _DecelerateSpeed;
        [SerializeField, ReadOnly] private float _JumpHeight;


        public override void Initialize(StateMachine father)
        {
            base.Initialize(father);
            _JumpSpeed = Mathf.Sqrt(2 * _Gravity * _JumpHeight);
            _AccelerateSpeed = _MaxSpeed / _AccelerateTime;
            _DecelerateSpeed = _MaxSpeed / _DecelerateTime;
        }
        public override void Enter()
        {
            _Paramaters.JumpBuffer = -1;
            _JumpHeight = _JumpHeightMap.Evaluate(_Paramaters.ChargePercent) * _MaxJumpHeight;
            _JumpSpeed = Mathf.Sqrt(2 * _Gravity * _JumpHeight); //可注释，用于调试最合适的重力
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