using System;
using UnityEngine;

namespace State.PlayerControl
{
    [Serializable]
    [CreateAssetMenu(fileName = "ClimbWallState", menuName = "ScriptableObject/PlayerControl/State/ClimbWall")]
    public class ClimbWallState : State
    {
        [Header("Config")]
        [SerializeField] private float _MaxSpeed;
        [SerializeField] private float _AccelerateTime;
        [SerializeField] private float _DecelerateTime;
        [Tooltip("爬墙跳时给予的横向速度（推力）")]
        [SerializeField] private float _JumpSpeed;

        [Header("Information")]
        [SerializeField, ReadOnly] private float _ClimbSpeed;
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
            _Paramaters.Velocity.Set(0, 0);
        }
        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            if (_Paramaters.MoveY == 0)
            {
                _ClimbSpeed = Mathf.MoveTowards(_ClimbSpeed, 0, Time.deltaTime * _DecelerateSpeed);
            }
            else
            {
                _ClimbSpeed += _Paramaters.MoveY * _AccelerateSpeed * Time.deltaTime;
                _ClimbSpeed = Mathf.Clamp(_ClimbSpeed, -_MaxSpeed, _MaxSpeed);
            }
            _Paramaters.Velocity.y = _ClimbSpeed;
        }
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (!_Paramaters.IsWall)
            {
                _FatherStateMachine.SwitchState(typeof(JumpState));
            }
            else if (_Paramaters.IsDash)
            {
                _FatherStateMachine.SwitchState(typeof(DashState));
            }
            else if (_Paramaters.JumpBuffer > 0)
            {
                _Paramaters.IsWall = false;
                _Paramaters.Velocity.x = _JumpSpeed * (_Paramaters.IsRightSideWall?-1:1);
                _FatherStateMachine.SwitchState(typeof(JumpState));
            }
            else if (!_Paramaters.IsHeld)
            {
                _FatherStateMachine.SwitchState(typeof(FallState));
            }
        }
    }
}
